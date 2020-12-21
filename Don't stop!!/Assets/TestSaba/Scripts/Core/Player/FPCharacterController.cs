using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Doozy.Engine.Attributes;
using UnityEditor;

namespace DontStop.Player
{
    /// <summary>
    /// ｷｬﾗｸﾀｰの状態の更新
    /// </summary>
    public enum MotionState
    {
        Idle,
        Walking,
        Running,
        Crouched,
        Climbing,
        Flying
    }

    /// <summary>
    /// 傾くべき方向
    /// </summary>
    public enum LeanState
    {
        Center = 0,
        Left = 1,
        Right = -1
    }

    [CustomEditor(typeof(CameraController))]
    [RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(CapsuleCollider)), DisallowMultipleComponent]
    public class FPCharacterController : MonoBehaviour
    {
        #region
        #endregion

        #region CHARACTER SETTINGS

        [SerializeField]
        [Range(1, 90)]
        [Tooltip("ｷｬﾗｸﾀｰが登れる傾斜面の角度")]
        private float slopeLimit = 50;

        [SerializeField]
        [Range(0.05f, 0.5f)]
        [Tooltip("ｷｬﾗｸﾀｰが登れる段差値より小さいと登れる")]
        private float stepOffset = 0.25f;

        [SerializeField]
        [Range(1.5f, 2)]
        [Tooltip("ｷｬﾗｸﾀｰのｶﾌﾟｾﾙｺﾗｲﾀﾞｰの高さ(ﾒｰﾄﾙ単位)")]
        private float characterHeight = 1.8f;

        [SerializeField]
        [Range(0.6f, 1.4f)]
        [Tooltip("ｷｬﾗｸﾀｰのｶﾌﾟｾﾙｺﾗｲﾀﾞｰの直径(ﾒｰﾄﾙ単位)")]
        private float characterShoulderWidth = 0.8f;

        [SerializeField]
        [Range(50, 100)]
        [Tooltip("ｷｬﾗｸﾀｰの質量(動きに影響する)")]
        private float characterWeight = 80;

        [SerializeField]
        [Range(0.9f, 1.3f)]
        [Tooltip("しゃがんでいるときの高さ")]
        private float crouchingHeight = 1.25f;

        [SerializeField]
        [Range(0.8f, 1.3f)]
        [Tooltip("ｽﾗｲﾃﾞｨﾝｸﾞ中のときの高さ")]
        private float slidingHeight = 0.9f;

        [SerializeField]
        [Range(0.001f, 10f)]
        [Tooltip("立ち状態と低姿勢状態(ｽﾗｲﾃﾞｨﾝｸﾞ,しゃがみ)の移行速度")]
        private float crouchingSpeed = 0.5f;

        [SerializeField]
        [Tooltip("走るときのﾓｰﾄﾞ(ｵｰﾄﾗﾝ, 切り替え式)true = ｵｰﾄﾗﾝ")]
        private bool runMode = true;

        [SerializeField]
        [Range(0, 1)]
        [Tooltip("当たり判定の許容値")]
        private float allowedCollider = 0.5f;
        
        #endregion

        #region MOVEMENT

        [SerializeField]
        [Range(0, 1)]
        [Tooltip("飛んでいるときの移動する力でｷｬﾗｸﾀｰがどの程度影響を受けるか")]
        private float airControlPercent = 0.5f;

        [SerializeField]
        [Range(0.1f, 10)]
        [Tooltip("歩くときにｷｬﾗｸﾀｰに適用する力")]
        private float walkingForce = 4.25f;

        [SerializeField]
        [Range(0.1f, 5)]
        [Tooltip("しゃがみ中のｷｬﾗｸﾀｰに適用する力")]
        private float crouchForce = 2f;

        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("この値にwalkingForceをかけて走る力にする")]
        private float runMultiplier = 2.25f;

        [SerializeField]
        [Range(0, 1)]
        [Tooltip("ｵｰﾄｽﾌﾟﾘﾝﾄ設定の時の走りに切り替わるまでの時間")]
        private float autoSprint = 0.5f;

        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("ｼﾞｬﾝﾌﾟするときに適用する力")]
        private float jumpForce = 9f;

        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("Physics.gravityにこれをかけて重力にする")]
        private float gravityMultiplier = 1f;

        #endregion

        #region SKILL

        [SerializeField]
        [Tooltip("このｷｬﾗｸﾀｰが使用できるｽｷﾙ")]
        private Skill.CharacterSkill skill = new Skill.CharacterSkill();

        #endregion

        #region CAMERA CONTROLLER

        [SerializeField]
        [Tooltip("ｶﾒﾗの動きと関連機能の処理")]
        private CameraController cameraController = new CameraController();

        [SerializeField]
        [Required]
        [Tooltip("このｷｬﾗｸﾀｰが使用するｶﾒﾗ")]
        private Camera FPSCamera;

        #endregion

        #region PARKOUR

        public bool wallRun { get; private set; }

        [SerializeField]
        [Range(5, 10)]
        [Tooltip("壁が走れる速度")]
        private float wallRunEnableSpeed = 8f;

        [SerializeField]
        [Range(0, 90)]
        [Tooltip("壁を走るときに向ける角度")]
        private float  wallRunAngle = 30f;

        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("壁ｼﾞｬﾝﾌﾟの時のｼﾞｬﾝﾌﾟ力")]
        private float wallJumpMultiplier = 1f;

        [SerializeField]
        [Required]
        [Tooltip("壁ｼﾞｬﾝﾌﾟの時のｼﾞｬﾝﾌﾟ力")]
        private CameraAnimator cameraAnimator;

        #endregion

        #region CLIMBING

        private bool climbing;

        [SerializeField]
        [Range(0.1f, 10)]
        [Tooltip("ｷｬﾗｸﾀｰが壁を登る速度.")]
        private float climbingSpeed = 3.5f;

        #endregion

        #region SLIDING

        /// <summary>
        /// ｽﾗｲﾃﾞｨﾝｸﾞ中か
        /// </summary>
        private bool isSliding;
        private Vector3 slidingThrust;
        private float slidingSinceTime;

        [SerializeField]
        [Range(0, 1)]
        [Tooltip("ｽﾗｲﾃﾞｨﾝｸﾞ中の移動する力でｷｬﾗｸﾀｰがどの程度影響を受けるか")]
        private float slidingControlPercent = 0.5f;

        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("ｽﾗｲﾃﾞｨﾝｸﾞが終わる推力")]
        private float slidingEndLine = 10f;

        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("ｽﾗｲﾃﾞｨﾝｸﾞの推力の最大値")]
        private float thrustMaxLimit = 10f;

        [SerializeField]
        [Range(0, 10)]
        [Tooltip("ｽﾗｲﾃﾞｨﾝｸﾞの抵抗")]
        private float slidingDrag = 5f;

        [SerializeField]
        [Range(0, 90)]
        [Tooltip("ｽﾗｲﾃﾞｨﾝｸﾞ可能な左右の角度")]
        private float slidingAngle = 20;

        [SerializeField]
        [Range(0, 90)]
        [Tooltip("ｽﾗｲﾃﾞｨﾝｸﾞで滑って加速していく角度")]
        private float frictionAngle = 20;

        [SerializeField]
        [Range(1, 2)]
        [Tooltip("ｽﾗｲﾃﾞｨﾝｸﾞ移行時の速度倍率")]
        private float thrustMultiplier = 1.1f;

        [SerializeField]
        [Range(0, 5)]
        [Tooltip("ｽﾗｲﾃﾞｨﾝｸﾞが再度出来るようになるまでの時間")]
        private float slidingRecastTime = 1;

        #endregion

        #region CROUCH

        /// <summary>
        /// しゃがむか
        /// </summary>
        private bool crouhing;

        /// <summary>
        /// しゃがんでいるかどうか
        /// </summary>
        public bool isCrouched { get; private set; }

        #endregion

        #region EVENTS

        public event System.Action ClimbingEvent;       // 登り
        public event System.Action JumpEvent;           // ｼﾞｬﾝﾌﾟ
        public event System.Action LandingEvent;        // 着地
        public event System.Action StartSlidingEvent;   // ｽﾗｲﾃﾞｨﾝｸﾞ開始
        public event System.Action EndSlidingEvent;     // ｽﾗｲﾃﾞｨﾝｸﾞ終了

        #endregion

        #region CONTROLLER PROPERTIES

        private Controller1.TestPlayerActions pController;

        /// <summary>
        /// ﾌﾟﾚｲﾔｰがｸﾞﾗｳﾝﾄﾞに接しているか()
        /// </summary>
        public bool grounded { get; private set; }

        /// <summary>
        /// ﾌﾟﾚｲﾔｰの入力をｷｬﾗが受け取れるかどうか
        /// </summary>
        public bool controllable { get; set; }

        /// <summary>
        /// ｴｲﾑしているかどうか
        /// </summary>
        public bool isAiming { get; set; }

        /// <summary>
        /// ｷｬﾗｸﾀｰを動かすために使用される現在の力
        /// </summary>
        public float CurrentTargetForce
        {
            get
            {
                if (isCrouched)
                {
                    return crouchForce;
                }

                if (running)
                {
                    return CurrentWalkingForce * runMultiplier;
                }

                return state == MotionState.Climbing ? climbingSpeed : CurrentWalkingForce;
            }
        }

        /// <summary>
        /// 歩くときに適用される力
        /// </summary>
        private float CurrentWalkingForce
        {
            get
            {
                return walkingForce;
            }
        }

        /// <summary>
        /// 重み係数でﾊﾞﾗﾝｽされたｼﾞｬﾝﾌﾟ力を返します。
        /// </summary>
        private float JumpForce
        {
            get
            {
                return jumpForce;
            }
        }

        /// <summary>
        /// 最終的な現在のｽﾗｲﾃﾞｨﾝｸﾞの推力を返します。
        /// </summary>
        private Vector3 SlidingThrust => slidingThrust;

        /// <summary>
        /// 速度、その時の角度によってﾊﾞﾗﾝｽされたｽﾗｲﾃﾞｨﾝｸﾞの抵抗を返します。
        /// </summary>
        /// <param name="nowAngle">速度から求めた角度</param>
        private float SlidingDrag(float nowAngle) => -slidingDrag - slidingDrag * (nowAngle / frictionAngle);

        /// <summary>
        /// 現在のﾓｰｼｮﾝ:idle
        /// </summary>
        public MotionState state { get; private set; } = MotionState.Idle;

        /// <summary>
        /// 傾くべき方向
        /// </summary>
        public LeanState leanState { get; private set; } = LeanState.Center;

        #endregion

        private CapsuleCollider capsule;
        private Rigidbody rigidbody;

        private float groundRelativeAngle;
        private Vector3 groundContactNormal;
        private Vector3 contactPoint;
        private bool slopedSurface;
        private int triangleIndex;

        private bool previouslyGrounded;    // 以前設置していたか
        private float groundedSpeed;        // 接地していた時の速度

        private bool jump;
        private bool jumping;
        private bool running;
        private float runTime;

        private void Awake()
        {
            pController = new Controller1().TestPlayer;

            // ｺｰﾙﾊﾞｯｸの登録
            pController.Jump.started += _ => South();
            pController.WpChange.started += _ => North();
            pController.Crouch.started += _ => East();
            pController.Chronostasis.started += _ => Skill1();
        }

        private void OnEnable()
        {
            pController.Enable();
        }

        private void OnDisable()
        {
            pController.Disable();
        }

        private void Start()
        {
            // -----Componentの取得,初期化
            capsule = GetComponent<CapsuleCollider>();
            rigidbody = GetComponent<Rigidbody>();
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            cameraController.Init(transform, FPSCamera.transform);
            FPSCamera.transform.localPosition = new Vector3(0, characterHeight * 0.4f, 0);

            // -----ｷｬﾗｸﾀｰｾｯﾃｨﾝｸﾞ
            capsule.height = characterHeight;
            capsule.radius = characterShoulderWidth * 0.5f; // 0.5f半径にする
            rigidbody.mass = characterWeight / 10f;
            
            // -----状態
            state = MotionState.Idle;
            leanState = LeanState.Center;

            // -----移動
            runTime = 0;

            // -----ﾊﾟﾙｸｰﾙ
            wallRun = false;

            // -----ｽﾗｲﾃﾞｨﾝｸﾞ
            slidingThrust = Vector3.zero;

            // -----しゃがみ

            // -----ｺﾝﾄﾛｰﾗｰ
            controllable = true;

            // -----ﾌﾚｰﾑごとの更新はしない処理
            InvokeRepeating(nameof(UpdateState), 0, 0.05f);
        }

        private void FixedUpdate()
        {
            // 移動軸
            Vector2 input = GetMoveInput();

            //CheckHitStatus();

            if (climbing)
            {
                ApplyClimbingVelocityChange(input);
            }
            else
            {
                ApplyInputVelocityChange(input);
            }

            ApplyGravityAndJumping(input);
        }

        /// <summary>
        /// 上昇速度の変更を適用する
        /// </summary>
        private void ApplyClimbingVelocityChange(Vector2 input)
        {
            //rigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }

        /// <summary>
        /// 入力速度変更を適用する
        /// </summary>
        private void ApplyInputVelocityChange(Vector2 input)
        {
            if (isSliding)
            {
                if (slidingThrust.magnitude < slidingEndLine)
                {
                    isSliding = false;
                    return;
                }
                
                if (!(rigidbody.velocity.sqrMagnitude < (SlidingThrust.sqrMagnitude))) return;

                // 角度による速度の調整
                var surfaceAngle = Vector3.Angle(groundContactNormal, Math.Math.EraseYAxis(rigidbody.velocity.normalized)) - 90;
                slidingThrust += slidingThrust.normalized * SlidingDrag(surfaceAngle) * Time.deltaTime;
                if (SlidingThrust.magnitude > thrustMaxLimit)
                {
                    slidingThrust = slidingThrust.normalized * thrustMaxLimit;
                }

                // 入力があれば
                if (Mathf.Abs(input.x) > Mathf.Epsilon || Mathf.Abs(input.y) > Mathf.Epsilon)
                {
                    // 移動方向の計算
                    var t = transform;
                    var desiredMove = t.forward * input.y + t.right * input.x;
                    desiredMove = Vector3.ProjectOnPlane(desiredMove, groundContactNormal);
                    desiredMove *= CurrentTargetForce * slidingControlPercent;
                    desiredMove = SlidingThrust + desiredMove;

                    rigidbody.AddForce(desiredMove, ForceMode.Impulse);
                }
                else
                {
                    rigidbody.AddForce(SlidingThrust, ForceMode.Impulse);
                }
            }
            else
            {
                // 入力があれば
                if (Mathf.Abs(input.x) > Mathf.Epsilon || Mathf.Abs(input.y) > Mathf.Epsilon)
                {
                    //if (!(rigidbody.velocity.sqrMagnitude < Mathf.Pow(CurrentTargetForce, 2))) return;

                    var planeVelocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
                    if (!grounded && !wallRun && planeVelocity.sqrMagnitude > groundedSpeed)
                    {
                        var y = rigidbody.velocity.y;
                        rigidbody.velocity = rigidbody.velocity * (1f - 5f * Time.deltaTime);
                        rigidbody.velocity = new Vector3(rigidbody.velocity.x, y, rigidbody.velocity.z);
                    }

                    // 移動方向の計算
                    var t = wallRun ? FPSCamera.transform : transform;
                    var desiredMove = t.forward * input.y + t.right * input.x;
                    // 何が違うのかわかんね
                    desiredMove = (desiredMove.sqrMagnitude > 1) ? Vector3.ProjectOnPlane(desiredMove, groundContactNormal).normalized : Vector3.ProjectOnPlane(desiredMove, groundContactNormal);

                    var force = grounded || wallRun ? CurrentTargetForce : CurrentTargetForce * airControlPercent;

                    desiredMove *= force;

                    rigidbody.AddForce(desiredMove, ForceMode.Impulse);
                }
            }
        }

        /// <summary>
        /// 重力とｼﾞｬﾝﾌﾟを適用する
        /// </summary>
        private void ApplyGravityAndJumping(Vector2 input)
        {
            if (grounded || climbing || wallRun)
            {
                rigidbody.drag = 5f;

                var velocity = rigidbody.velocity;
                velocity = new Vector3(velocity.x, 0f, velocity.z);

                if (jump)
                {
                    rigidbody.drag = 0f;
                    rigidbody.velocity = velocity;

                    Vector3 jumpDirForce = transform.rotation * cameraAnimator.TransformLeanUp() * JumpForce * 10f * (wallRun ? wallJumpMultiplier : 1f);
                    rigidbody.AddForce(jumpDirForce, ForceMode.Impulse);
                    jumping = true;

                    if (!climbing)
                        JumpEvent?.Invoke();
                }

                groundedSpeed = velocity.sqrMagnitude;

                if (!jumping && Mathf.Abs(input.x) < Mathf.Epsilon && Mathf.Abs(input.y) < Mathf.Epsilon && rigidbody.velocity.magnitude < 1f)
                {
                    rigidbody.Sleep();
                }
            }
            else
            {
                rigidbody.drag = 0f;

                var gravity = Physics.gravity * gravityMultiplier;

                if (rigidbody.velocity.magnitude < Mathf.Abs(gravity.y * characterWeight / 2))
                {
                    rigidbody.AddForce(gravity, ForceMode.Impulse);
                }

                if (previouslyGrounded && !jumping)
                {
                    StickToGroundHelper();
                }
            }

            jump = false;
        }

        /// <summary>
        /// 傾斜面、地面との接触を維持させる
        /// </summary>
        private void StickToGroundHelper()
        {
            if (!Physics.SphereCast(transform.position, capsule.radius * 0.9f, Vector3.down, out RaycastHit hitInfo,
                (1 - capsule.radius) + 0.1f, Physics.AllLayers, QueryTriggerInteraction.Ignore))
                return;

            if (Mathf.Abs(groundRelativeAngle) >= slopeLimit)
            {
                rigidbody.velocity = Vector3.ProjectOnPlane(rigidbody.velocity, hitInfo.normal);
            }
        }

        /// <summary>
        /// 接触、非接触の処理
        /// </summary>
        //private void CheckHitStatus()
        //{
        //    previouslyGrounded = climbing ? previouslyGrounded : grounded;
        //    slopedSurface = Mathf.Abs(groundRelativeAngle) > slopeLimit;
        //    float offset = (1 - capsule.radius) + (slopedSurface ? 0.05f : stepOffset);

        //    // 自身のｺﾗｲﾀﾞｰを下方向に飛ばす
        //    var hitInfo = Physics.SphereCastAll(transform.position, capsule.radius, Vector3.down, capsule.height / 2 - capsule.radius + 0.2f);//rigidbody.SweepTestAll(Vector3.down, 0.5f, QueryTriggerInteraction.Ignore);
        //    Debug.Log(hitInfo.Length);
        //    for (int i = 0; i < hitInfo.Length; i++)
        //    {
        //        //UnityEditor.EditorApplication.isPaused = true;
        //        if (i == 0 || Mathf.Abs(groundRelativeAngle) > Mathf.Abs(Vector3.Angle(hitInfo[i].normal, Vector3.up)))
        //        {
        //            contactPoint = hitInfo[i].point;
        //            groundContactNormal = hitInfo[i].normal;
        //            groundRelativeAngle = Vector3.Angle(groundContactNormal, Vector3.up);
        //        }
        //    }

        //    if (hitInfo.Length >= 1)
        //    {
        //        //transform.position = new Vector3(transform.position.x, contactPoint.y + capsule.height / 2, transform.position.z);
        //        grounded = groundRelativeAngle < slopeLimit;
        //    }
        //    else
        //    {
        //        grounded = false;
        //    }

        //    if (!wallRun && !grounded)
        //    {
        //        groundContactNormal = Vector3.up;
        //        groundRelativeAngle = Vector3.Angle(groundContactNormal, Vector3.up);
        //        grounded = false;
        //    }

        //    //if (!grounded && jumping && running && Math.Math.EraseYAxis(rigidbody.velocity).magnitude > wallRunEnableSpeed
        //    //    && Mathf.Abs(Vector3.Angle(groundContactNormal, transform.forward) - 90) < wallRunAngle /*&& collision.transform.tag == "WallRun"*/)
        //    //{
        //    //    wallRun = true;
        //    //}
        //    //else
        //    //{
        //    //    wallRun = false;
        //    //}

        //    if (!previouslyGrounded && grounded && jumping)
        //    {
        //        jumping = false;
        //    }
        //}

        /// <summary>
        /// 接触時の処理
        /// </summary>
        private void OnCollisionStay(Collision collision)
        {
            previouslyGrounded = climbing ? previouslyGrounded : grounded;
            slopedSurface = Mathf.Abs(groundRelativeAngle) > slopeLimit;
            float offset = (1 - capsule.radius) + (slopedSurface ? 0.05f : stepOffset);

            triangleIndex = collision.contactCount;
            for (int i = 0; i < triangleIndex; i++)
            {
                contactPoint = collision.contacts[i].point;
                groundContactNormal = collision.contacts[i].normal;
                groundRelativeAngle = Vector3.Angle(groundContactNormal, Vector3.up);
                if (Mathf.Abs(groundRelativeAngle) < slopeLimit)
                {
                    grounded = true;
                    break;
                }
                else if (wallRun)
                {

                    grounded = false;
                    break;
                }
                else
                {
                    groundContactNormal = Vector3.up;
                    groundRelativeAngle = Vector3.Angle(groundContactNormal, Vector3.up);
                }
            }

            if (!grounded && jumping && running && Math.Math.EraseYAxis(rigidbody.velocity).magnitude > wallRunEnableSpeed
                && Mathf.Abs(Vector3.Angle(groundContactNormal, transform.forward) - 90) < wallRunAngle && collision.transform.tag == "WallRun")
            {
                wallRun = true;
            }
            else
            {
                wallRun = false;
            }

            if (!previouslyGrounded && grounded && jumping)
            {
                jumping = false;
            }
        }

        /// <summary>
        /// 離れた時の処理
        /// </summary>
        private void OnCollisionExit(Collision collision)
        {
            grounded = false;
            isCrouched = false;
            wallRun = false;
            groundContactNormal = Vector3.up;
        }

        private void Update()
        {

#if UNITY_EDITOR
            //Debug.Log(wallRun);
            //if (!grounded)
            //{
            //    if (GetMoveInput().y > Mathf.Epsilon)
            //    {
            //        UnityEditor.EditorApplication.isPaused = true;
            //    }
            //}
#endif

            // ｶﾒﾗの回転を更新
            cameraController.UpdateRotation(isAiming, GetViewInput());

            // ｽｷﾙの状態を更新
            skill.UpdateChronostasis();

            // 操作可能か
            if (controllable) HandleInput();

            if (grounded || previouslyGrounded || climbing)
            {
                previouslyGrounded = false;
            }

            if (grounded && !previouslyGrounded)
            {
                previouslyGrounded = true;
            }

            // 壁走り
            if (wallRun)
            {
                if (Vector3.Cross(transform.forward, contactPoint - transform.position).y < 0)
                {
                    leanState = LeanState.Left;
                }
                else
                {
                    leanState = LeanState.Right;
                }
            }
            else
            {
                leanState = LeanState.Center;
            }

            // ｶﾌﾟｾﾙとｶﾒﾗの高さを状態に応じて変更する
            if (isSliding)
            {
                // 1.25倍:ｽﾗｲﾃﾞｨﾝｸﾞは早めに下げるため
                ScaleCapsuleForCrouching(isSliding, slidingHeight, crouchingSpeed * 1.25f);
            }
            else if (isCrouched)
            {
                ScaleCapsuleForCrouching(isCrouched, crouchingHeight, crouchingSpeed);
            }
            else
            {
                ScaleCapsuleForCrouching(isSliding, characterHeight, crouchingSpeed);
            }
        }

        /// <summary>
        /// 入力を処理
        /// </summary>
        private void HandleInput()
        {
            CheckRunning();

            if (!isSliding && slidingSinceTime <= slidingRecastTime)
            {
                slidingSinceTime += Time.deltaTime;
            }

            if (grounded)
            {
                if (!crouhing)
                {
                    isCrouched = false;
                    isSliding = false;
                    return;
                }

                isCrouched = true;
                if (running && Vector3.Angle(new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z), transform.forward) < slidingAngle 
                    && !isSliding && slidingSinceTime >= slidingRecastTime)
                {
                    var thrustPower = thrustMultiplier - (Vector3.Angle(groundContactNormal, Math.Math.EraseYAxis(rigidbody.velocity.normalized)) - 90) / 90;
                    slidingThrust = Vector3.ProjectOnPlane(rigidbody.velocity, groundContactNormal) * thrustPower;
                    slidingSinceTime = 0;
                    isSliding = true;
                }
            }
        }

        /// <summary>
        /// Prevent the character from standing up.
        /// </summary>
        private bool PreventStandingInLowHeadroom(Vector3 position)
        {
            Ray ray = new Ray(position + capsule.center + new Vector3(0, capsule.height * 0.25f), transform.TransformDirection(Vector3.up));

            return Physics.SphereCast(ray, capsule.radius * 0.75f, out _, isCrouched ? characterHeight * 0.6f : jumpForce * 0.12f,
                Physics.AllLayers, QueryTriggerInteraction.Ignore);
        }

        /// <summary>
        /// ｷｬﾗｸﾀｰの状態に応じたｶﾌﾟｾﾙのｽｹｰﾙ設定を適用
        /// </summary>
        /// <param name="IsCrouched">ｷｬﾗｸﾀｰがしゃがんでいるか</param>
        /// <param name="height">ｶﾌﾟｾﾙの高さ</param>
        /// <param name="crouchingSpeed">しゃがむ速度</param>
        private void ScaleCapsuleForCrouching(bool IsCrouched, float height, float crouchingSpeed)
        {
            if (IsCrouched)
            {
                if (Mathf.Abs(capsule.height - height) > Mathf.Epsilon)
                {
                    //m_PlayerFootstepsSource.ForcePlay(m_CrouchingDownSound, m_CrouchingVolume);
                    //m_NextStep = m_CrouchingDownSound.length + Time.time;
                }

                capsule.height = height;
                capsule.radius = characterShoulderWidth * 0.5f;
                capsule.center = new Vector3(0, -(characterHeight - height) / 2, 0);

                FPSCamera.transform.localPosition = Vector3.MoveTowards(FPSCamera.transform.localPosition, new Vector3(0, height - 1, 0),
                    Time.deltaTime * crouchingSpeed);
            }
            else
            {
                if (Mathf.Abs(capsule.height - characterHeight) > Mathf.Epsilon)
                {
                    //m_PlayerFootstepsSource.ForcePlay(m_StandingUpSound, m_CrouchingVolume);
                    //m_NextStep = m_StandingUpSound.length + Time.time;
                }

                capsule.height = characterHeight;
                capsule.radius = characterShoulderWidth * 0.5f;
                capsule.center = Vector3.zero;

                FPSCamera.transform.localPosition = Vector3.MoveTowards(FPSCamera.transform.localPosition, new Vector3(0, characterHeight * 0.4f, 0),
                    Time.deltaTime * crouchingSpeed);
            }
        }

        private void LateUpdate()
        {
            
        }

        /// <summary>
        /// ｷｬﾗｸﾀｰの状態の更新
        /// </summary>
        private void UpdateState()
        {
            if (climbing)
            {
                state = MotionState.Climbing;
            }
            if (grounded)
            {
                // (動いていて、走っていたら),(動いていたら),(動いてない)
                if (rigidbody.velocity.sqrMagnitude > Mathf.Epsilon && running)
                {
                    state = MotionState.Running;
                }
                else if (rigidbody.velocity.sqrMagnitude > Mathf.Epsilon)
                {
                    state = MotionState.Walking;
                }
                else
                {
                    state = MotionState.Idle;
                }

                if (isCrouched)
                {
                    state = MotionState.Crouched;
                }
            }
            else
            {
                state = MotionState.Flying;

                if (wallRun)
                {
                    state = MotionState.Running;
                }
            }
        }

        /// <summary>
        /// ﾃﾞﾊﾞｯｸﾞ用
        /// </summary>
        private void OnDrawGizmos()
        {
            /*
            Gizmos.color = Color.red;
            //Gizmos.DrawLine(transform.position, contactPoint);

            Gizmos.DrawSphere(transform.position + (Vector3.down * (capsule.height / 2 - capsule.radius) + Vector3.down * 0.2f), capsule.radius);
            var hitInfo2 = Physics.SphereCastAll(transform.position, capsule.radius, Vector3.down, capsule.height / 2 - capsule.radius + 0.2f);
            for (int i = 0; i < hitInfo2.Length; i++)
            {
                Gizmos.DrawLine(transform.position, hitInfo2[i].point);
            }
            */
        }

        private Vector3 vec1;
        private Vector3 vec2;
        private Vector3 vec3;
        private void OnGUI()
        {
            /*
            var style = new GUIStyle();
            style.fontSize = 50;
            style.normal.textColor = Color.red;
            GUI.Label(new Rect(0, 0, 100, 50), "速度の角度:" + (90-Vector3.Angle(rigidbody.velocity, Vector3.up)), style);
            GUI.Label(new Rect(0, 50, 100, 50), "接触面の角度:" + (Vector3.Angle(groundContactNormal, Math.Math.EraseYAxis(rigidbody.velocity.normalized)) - 90), style);

            // ﾌﾟﾚｲﾔｰの向きに対する壁の角度
            GUI.Label(new Rect(0, 100, 100, 50), "壁に対するﾌﾟﾚｲﾔｰの角度:" + Mathf.Abs(Vector3.Angle(groundContactNormal, transform.forward) - 90), style);

            GUI.Label(new Rect(0, 150, 100, 50), "左右判定:" + (Vector3.Cross(transform.forward, contactPoint - transform.position)), style);
            GUI.Label(new Rect(0, 200, 100, 50), "ﾏｳｽの入力:" + GetViewInput(), style);

            GUI.Label(new Rect(0, 300, 100, 50), "最大:" + (SlidingThrust.magnitude) + "現在:" + rigidbody.velocity.magnitude, style);
            GUI.Label(new Rect(0, 350, 100, 50), "ああい:" + SlidingDrag((Vector3.Angle(groundContactNormal, Math.Math.EraseYAxis(rigidbody.velocity.normalized)) - 90)), style);
            */
        }

        /// <summary>
        /// ﾌﾟﾚｲﾔｰの入力からｷｬﾗｸﾀｰが走っているか確認する
        /// </summary>
        private void CheckRunning()
        {
            // 移動していたら(Y軸は考慮しない)
            if (Math.Math.EraseYAxis(rigidbody.velocity).magnitude > Mathf.Epsilon)
            {
                runTime += Time.deltaTime;
            }
            else
            {
                runTime = 0;
            }

            // ｴｲﾑしてなくて、登ってなくて、移動し始めて一定時間が経過したとき
            if (!isAiming && !climbing && !isCrouched && runTime > autoSprint)
            {
                if (Input.GetKey(KeyCode.V) || runMode)
                {
                    running = true;
                }
            }
            else
            {
                running = false;
            }
        }

        #region INPUTREGISTER

        /// <summary>
        /// 左ｽﾃｨｯｸ、WASDの入力値を返す
        /// </summary>
        private Vector2 GetMoveInput()
        {
            if (!controllable) return Vector2.zero;
            return pController.Move.ReadValue<Vector2>();
        }

        /// <summary>
        /// 右ｽﾃｨｯｸ、ﾏｳｽの入力値を返す
        /// </summary>
        private Vector2 GetViewInput()
        {
            return pController.Direction.ReadValue<Vector2>();
        }

        // 東,B,(LShift,LCtrl)
        private void East()
        {
            // 地面についているときしゃがむ(切り替え)
            if (grounded && !jump && !jumping)
            {
                crouhing = !crouhing;
            }
            //Debug.Log("しゃがみ、ｽﾗｲﾃﾞｨﾝｸﾞ");
        }

        // 南,A,(Space)
        private void South()
        {
            crouhing = false;
            jump = true;
            //Debug.Log("ｼﾞｬﾝﾌﾟ、決定");
        }

        // 北,Y,(C)
        private void North()
        {
            Debug.Log("武器ﾁｪﾝ");
        }

        // L,R,(MouseWheelの押し込み)
        private void Skill1()
        {
            // 切り替え
            skill.chronostasis = !skill.chronostasis;
        }
        
        #endregion
    }
}
