using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Doozy.Engine.Attributes;

public class FPCharacterController : MonoBehaviour
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

    #region
    #endregion

    #region CHARACTER SETTINGS

    [SerializeField]
    [Range(1,90)]
    [Tooltip("ｷｬﾗｸﾀｰが登れる傾斜面の角度")]
    private float slopeLimit = 50;

    [SerializeField]
    [Range(0.05f, 0.5f)]
    [Tooltip("ｷｬﾗｸﾀｰが登れる段差値より小さいと登れる")]
    private float stepOffset = 0.25f;

    [SerializeField]
    [Range(1.5f, 2.1f)]
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
    [MinMaxRange(0, Mathf.Infinity)]
    [Tooltip("ｼﾞｬﾝﾌﾟするときに適用する力")]
    private float jumpForce = 9f;

    [SerializeField]
    [MinMaxRange(0, Mathf.Infinity)]
    [Tooltip("Physics.gravityにこれをかけて重力にする")]
    private float gravityMultiplier = 1f;

    #endregion

    #region CAMERA CONTROLLER

    [SerializeField]
    [Tooltip("ｶﾒﾗの動きと関連機能の処理")]
    private CameraController cameraController;

    [SerializeField]
    [Tooltip("このｷｬﾗｸﾀｰが使用するｶﾒﾗ")]
    private Camera FPSCamera;

    #endregion

    #region PARKOUR


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
    /// ｽﾗｲﾃﾞｨﾝｸﾞするか
    /// </summary>
    private bool sliding;

    /// <summary>
    /// ｽﾗｲﾃﾞｨﾝｸﾞ中か
    /// </summary>
    private bool isSliding;

    #endregion

    #region EVENTS

    public event System.Action ClimbingEvent;       // 登り
    public event System.Action JumpEvent;           // ｼﾞｬﾝﾌﾟ
    public event System.Action LandingEvent;        // 着地
    public event System.Action StartSlidingEvent;   // ｽﾗｲﾃﾞｨﾝｸﾞ開始
    public event System.Action EndSlidingEvent;     // ｽﾗｲﾃﾞｨﾝｸﾞ終了

    #endregion

    #region CONTROLLER PROPERTIES

    private Controller1 controller = null;


    /// <summary>
    /// ﾌﾟﾚｲﾔｰがｸﾞﾗｳﾝﾄﾞに接しているか()
    /// </summary>
    public bool grounded { get; private set; }

    /// <summary>
    /// ﾌﾟﾚｲﾔｰの入力をｷｬﾗが受け取れるかどうか
    /// </summary>
    public bool controllable { get; set; }

    /// <summary>
    /// しゃがんでいるかどうか
    /// </summary>
    public bool IsCrouched { get; private set; }

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
            if (IsCrouched)
            {
                return crouchForce;
            }

            if (running)
            {
                return CurrentWalkingForce * runMultiplier;// * (m_Stamina ? 1 + (m_StaminaAmount * (m_RunMultiplier - 1)) / m_MaxStaminaAmount : m_RunMultiplier); ←ｽﾀﾐﾅがあるとき
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
            // ﾀﾞﾒｰｼﾞを受けている
            //if (LowerBodyDamaged)
            //{
            //    return walkingForce * 0.7f;
            //}

            return walkingForce;// * WeightFactor; ←押したりするものがあるときに使う
        }
    }

    /// <summary>
    /// 重み係数でバランスされたジャンプ力を返します。
    /// </summary>
    private float JumpForce
    {
        get
        {
            //if (!m_Stamina || !m_WeightAffectJump)
            //    return m_JumpForce;

            return jumpForce;// * WeightFactor;
        }
    }

    /// <summary>
    /// ｷｬﾗｸﾀｰが運ぶ重さによる力の損失を返す
    /// </summary>
    private float WeightFactor
    {
        get
        {
            //if (!m_Stamina)
                return 1;

            //float factor = Mathf.Clamp01(1 + m_MaxSpeedLoss - ((1 - m_MaxSpeedLoss) * Weight + m_MaxWeight * m_MaxSpeedLoss) / m_MaxWeight);
            //return factor;
        }
    }

    /// <summary>
    /// 現在のﾓｰｼｮﾝ:idle
    /// </summary>
    public MotionState state { get; private set; } = MotionState.Idle;

    #endregion

    private CapsuleCollider capsule;
    private Rigidbody rigidbody;
    
    private float groundRelativeAngle;
    private Vector3 groundContactNormal;
    private Vector3 groundContactPoint;
    private bool slopedSurface;
    private int triangleIndex;

    private bool previouslyGrounded;    // 以前設置していたか

    private bool jump;
    private bool jumping;
    private bool running;

    private void Awake()
    {
        controller = new Controller1();

        // ｺｰﾙﾊﾞｯｸの登録

        // まだ割り当てなし
        controller.TestPlayer.Jump.started += _ => South();
        controller.TestPlayer.WpChange.started += _ => North();
        controller.TestPlayer.Crouch.started += _ => East();
        controller.TestPlayer.Reload.started += _ => West();
        controller.TestPlayer.Shoot.started += _ => Shoot();
        controller.TestPlayer.Aim.started += _ => Aim();
    }

    private void OnEnable()
    {
        controller.Enable();
    }

    private void OnDisable()
    {
        controller.Disable();
    }

    private void OnDestroy()
    {
        controller.Dispose();
    }

    private void Start()
    {
        capsule = GetComponent<CapsuleCollider>();
        rigidbody = GetComponent<Rigidbody>();
        cameraController = new CameraController();
        cameraController.Init(transform, FPSCamera.transform);

        // ｽﾗｲﾃﾞｨﾝｸﾞ
        sliding = false;

        // ｺﾝﾄﾛｰﾗｰ
        controllable = true;

        // ﾌﾚｰﾑごとの更新はしない処理
        InvokeRepeating(nameof(UpdateState), 0, 0.05f);
        InvokeRepeating(nameof(CheckGroundStatus), 0, 0.05f);
    }

    private void FixedUpdate()
    {
        // 移動軸
        Vector2 input = GetMoveInput();

        if (climbing)
        {
            //ApplyClimbingVelocityChange(input);
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

    }

    /// <summary>
    /// 入力速度変更を適用する
    /// </summary>
    private void ApplyInputVelocityChange(Vector2 input)
    {
        if (sliding)
        {

        }
        else
        {
            // 入力があれば
            if (Mathf.Abs(input.x) - Mathf.Epsilon > 0 || Mathf.Abs(input.y) - Mathf.Epsilon > 0)
            {
                // 移動方向の計算
                var t = transform;
                var desiredMove = t.forward * input.y + t.right * input.x;
                desiredMove = (desiredMove.sqrMagnitude > 1) ? Vector3.ProjectOnPlane(desiredMove, groundContactNormal).normalized : Vector3.ProjectOnPlane(desiredMove, groundContactNormal);

                desiredMove.x *= (grounded ? CurrentTargetForce : CurrentTargetForce * airControlPercent);
                desiredMove.z *= (grounded ? CurrentTargetForce : CurrentTargetForce * airControlPercent);
                desiredMove.y = desiredMove.y * (grounded ? CurrentTargetForce : CurrentTargetForce * airControlPercent);

                if (rigidbody.velocity.sqrMagnitude < (CurrentTargetForce * CurrentTargetForce))
                {
                    rigidbody.AddForce(desiredMove, ForceMode.Impulse);
                }
            }
        }
    }

    /// <summary>
    /// 重力とｼﾞｬﾝﾌﾟを適用する
    /// </summary>
    private void ApplyGravityAndJumping(Vector2 input)
    {
        if (grounded || climbing)
        {
            rigidbody.drag = 5f;

            if (jump)
            {
                rigidbody.drag = 0f;
                Vector3 velocity = rigidbody.velocity;
                velocity = new Vector3(velocity.x, 0f, velocity.z);
                rigidbody.velocity = velocity;
                rigidbody.AddForce(new Vector3(0f, JumpForce * 10, 0f), ForceMode.Impulse);
                jumping = true;

                if (!climbing)
                    JumpEvent?.Invoke();
            }

            if (!jumping && Mathf.Abs(input.x) < float.Epsilon && Mathf.Abs(input.y) < float.Epsilon && rigidbody.velocity.magnitude < 1f)
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
    /// 傾斜面d地面との接触を維持させる
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

    private void Update()
    {
        // ｶﾒﾗの回転を更新
        cameraController.UpdateRotation(isAiming, GetViewInput());

        // 操作可能か
        if (controllable) HandleInput();

        if (grounded || (previouslyGrounded || climbing))
        {
            previouslyGrounded = false;
        }

        if (grounded && !previouslyGrounded)
        {
            previouslyGrounded = true;
        }
    }

    /// <summary>
    /// 入力を処理
    /// </summary>
    private void HandleInput()
    {
        // 接地しているか、ｽﾗｲﾃﾞｨﾝｸﾞしていないか、登ってないか、
        if (grounded && !sliding && !climbing)
        {
            
        }
        
        CheckRunning();
    }

    private void LateUpdate()
    {
        
    }

    /// <summary>
    /// ｷｬﾗｸﾀｰの状態の更新
    /// </summary>
    private void UpdateState()
    {

    }

    /// <summary>
    /// ｷｬﾗｸﾀｰの足と地面との間の角度
    /// </summary>
    private float CalculateGroundRelativeAngle(bool ignoreEnvironment)
    {
        Vector3 normal = Vector3.up;

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, capsule.height + stepOffset, Physics.AllLayers, QueryTriggerInteraction.Ignore))
        {
            normal = hitInfo.normal;
        }

        if (ignoreEnvironment)
            return Vector3.Angle(normal, Vector3.up);

        Vector3 position = transform.position;
        Vector3 footPos = new Vector3(position.x, position.y - (characterHeight * 0.5f - stepOffset), position.z);
        if (Physics.Raycast(footPos, transform.TransformDirection(Vector3.forward), characterHeight * 2, Physics.AllLayers, QueryTriggerInteraction.Ignore))
        {
            return Vector3.Angle(normal, Vector3.up);
        }

        return -Vector3.Angle(normal, Vector3.up);

    }

    /// <summary>
    /// ﾚｲを下に向きにｷｬｽﾄしｷｬﾗが接地しているか確認する
    /// </summary>
    private void CheckGroundStatus()
    {
        previouslyGrounded = climbing ? previouslyGrounded : grounded;
        //m_PreviouslyJumping = m_Jumping;
        slopedSurface = Mathf.Abs(groundRelativeAngle) > slopeLimit;
        float offset = (1 - capsule.radius) + (slopedSurface ? 0.05f : stepOffset);

        if (Physics.SphereCast(transform.position, capsule.radius * 0.9f, -transform.up, out RaycastHit hitInfo, offset, Physics.AllLayers, QueryTriggerInteraction.Ignore))
        {
            groundContactNormal = hitInfo.normal;
            groundContactPoint = hitInfo.point;
            groundRelativeAngle = CalculateGroundRelativeAngle(false);
            grounded = Mathf.Abs(groundRelativeAngle) < slopeLimit;

            triangleIndex = hitInfo.triangleIndex;
            //m_Surface = hitInfo.collider.GetSurface();
        }
        else
        {
            grounded = false;
            IsCrouched = false;
            groundContactNormal = Vector3.up;
        }

        
        //if (!m_PreviouslyGrounded && grounded && jumping)
        //{
        //    m_Jumping = false;
        //}
    }

    /// <summary>
    /// ﾌﾟﾚｲﾔｰの入力からｷｬﾗｸﾀｰが走っているか確認する
    /// </summary>
    private void CheckRunning()
    {
        var input = GetMoveInput();
        // 入力があれば
        if (Mathf.Abs(input.x) - Mathf.Epsilon > 0 || Mathf.Abs(input.y) - Mathf.Epsilon > 0)
        {
            running = true;
        }


        //if (!LowerBodyDamaged && GetMoveInput().y > 0 && !IsAiming && !m_Climbing)
        //{
        //    if (GameplayManager.Instance.SprintStyle == ActionMode.Hold)
        //    {
        //        running = InputManager.GetButton(m_RunButton);
        //    }
        //    else
        //    {
        //        if (InputManager.GetButtonDown(m_RunButton))
        //        {
        //            running = !running;
        //        }
        //    }
        //}
        //else
        //{
        //    running = false;
        //}
    }

    /// <summary>
    /// 左ｽﾃｨｯｸ、WASDの入力値を返す
    /// </summary>
    private Vector2 GetMoveInput()
    {
        if (!controllable) return Vector2.zero;
        return controller.TestPlayer.Move.ReadValue<Vector2>();
    }

    /// <summary>
    /// 右ｽﾃｨｯｸ、ﾏｳｽの入力値を返す
    /// </summary>
    private Vector2 GetViewInput()
    {
        return controller.TestPlayer.Direction.ReadValue<Vector2>();
    }

    // 東,B
    private void East()
    {
        Debug.Log("しゃがみ、ｽﾗｲﾃﾞｨﾝｸﾞ");
    }

    // 西,X
    private void West()
    {
        Debug.Log("ﾘﾛｰﾄﾞ");
    }

    // 南,A
    private void South()
    {
        jump = true;
        Debug.Log("ｼﾞｬﾝﾌﾟ、決定");
    }

    // 北,Y
    private void North()
    {
        Debug.Log("武器ﾁｪﾝ");
    }

    // RT
    private void Shoot()
    {
        Debug.Log("弾を撃つ");
    }

    // LT
    private void Aim()
    {
        FPSCamera.fieldOfView = 40;
        Debug.Log("狙う(ちょいｽﾞｰﾑ)");
    }
}
