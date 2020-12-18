using UnityEngine;
using Doozy.Engine.Attributes;

namespace DontStop.Player
{
    [System.Serializable]
    public class CameraController
    {
        /// <summary>
        /// Defines how horizontally sensitive the camera will be to mouse movement.
        /// </summary>
        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("Defines how horizontally sensitive the camera will be to mouse movement.")]
        private float m_YawSensitivity = 3f;

        /// <summary>
        /// Defines how vertically sensitive the camera will be to mouse movement.
        /// </summary>
        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("Defines how vertically sensitive the camera will be to mouse movement.")]
        private float m_PitchSensitivity = 3f;

        /// <summary>
        /// Defines how horizontally sensitive the camera will be to mouse movement while aiming.
        /// </summary>
        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("Defines how horizontally sensitive the camera will be to mouse movement while aiming.")]
        private float m_AimingYawSensitivity = 1f;

        /// <summary>
        /// Defines how vertically sensitive the camera will be to mouse movement while aiming.
        /// </summary>
        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("Defines how vertically sensitive the camera will be to mouse movement while aiming.")]
        private float m_AimingPitchSensitivity = 1f;

        /// <summary>
        /// Limits the camera’s vertical rotation (pitch).
        /// </summary>
        [SerializeField]
        [Tooltip("Limits the camera’s vertical rotation (pitch).")]
        private bool m_LimitPitchRotation = true;

        /// <summary>
        /// Defines how fast the camera will decelerate.
        /// </summary>
        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("Defines how fast the camera will decelerate.")]
        private float smoothness = 0.0f;

        [SerializeField]
        [MinMaxRange(-90f, 90f)]
        [Tooltip("ｶﾒﾗの最大最小角度")]
        private Vector2 pitchLimit = new Vector2(-75f, 80);

        [SerializeField]
        [Tooltip("ｶﾒﾗ垂直方向の反転")]
        private bool invertVerticalAxis = false;

        [SerializeField]
        [Tooltip("ｶﾒﾗ水平方向の反転")]
        private bool invertHorizontalAxis = false;
        
        private Transform characterReference;
        private Transform cameraReference;

        private Quaternion characterTargetRot;
        private Quaternion cameraTargetRot;

        private float minPitch;
        private float maxPitch;

        #region PROPERTIES

        /// <summary>
        /// ｶﾒﾗｺﾝﾄﾛｰﾗｰが入力を受け取れるか
        /// </summary>
        public bool controllable
        {
            get;
            set;
        }

        /// <summary>
        /// ｶﾒﾗ制御のための感度
        /// </summary>
        public Vector2 currentSensitivity
        {
            private set;
            get;
        }

        /// <summary>
        /// ｷｬﾗが回転している方向を確認する
        /// </summary>
        public float currentYaw
        {
            get;
            private set;
        }

        #endregion

        /// <summary>
        /// ｷｬﾗｸﾀｰの初期rotationで初期化する
        /// </summary>
        /// <param name="character">操作ｷｬﾗのtransform</param>
        /// <param name="camera">ｶﾒﾗのtransform</param>
        public void Init(Transform character, Transform camera)
        {
            characterReference = character;
            cameraReference = camera;

            characterTargetRot = character.localRotation;
            cameraTargetRot = camera.localRotation;

            minPitch = pitchLimit.x;
            maxPitch = pitchLimit.y;

            controllable = true;
        }

        /// <summary>
        /// ｷｬﾗｸﾀｰを強制的に指定した位置に向かせる
        /// </summary>
        /// <param name="position">向かせたい場所</param>
        public void LookAt(Vector3 position)
        {
            Vector3 characterDirection = position - characterReference.position;
            characterDirection.y = 0;

            // Forces the character to look at the target position.
            characterTargetRot = Quaternion.Slerp(characterTargetRot, Quaternion.LookRotation(characterDirection), 10 * Time.deltaTime);
            characterReference.localRotation = Quaternion.Slerp(characterReference.localRotation, characterTargetRot, 10 * Time.deltaTime);
        }

        /// <summary>
        /// ｷｬﾗｸﾀｰのｶﾒﾗを行動に合わせたﾋﾟｯﾁ設定にする
        /// </summary>
        /// <param name="overridePitchLimit">新しく設定したﾋﾟｯﾁを使うかどうか</param>
        /// <param name="newMinPitch">新しい最小ﾋﾟｯﾁ</param>
        /// <param name="newMaxPitch">新しい最大ﾋﾟｯﾁ</param>
        public void OverrideCameraPitchLimit(bool overridePitchLimit, float newMinPitch, float newMaxPitch)
        {
            minPitch = overridePitchLimit ? newMinPitch : pitchLimit.x;
            maxPitch = overridePitchLimit ? newMaxPitch : pitchLimit.y;
        }

        /// <summary>
        /// ﾌﾟﾚｲﾔｰの入力でｷｬﾗとｶﾒﾗのの回転を更新する(時間に関係なく動く)
        /// </summary>
        /// <param name="isAiming">ｷｬﾗｸﾀｰがｴｲﾑしていいるか</param>
        public void UpdateRotation(bool isAiming, Vector2 axis)
        {
            if (!controllable)
                return;

            // 一時停止中に動かないようにする
            if (Mathf.Abs(Time.timeScale) < float.Epsilon)
                return;

            currentSensitivity = new Vector2(isAiming ? m_AimingYawSensitivity : m_YawSensitivity, isAiming ? m_AimingPitchSensitivity : m_PitchSensitivity);
            
            // 反転機能
            float xRot = (invertVerticalAxis ? -axis.y : axis.y)
                * currentSensitivity.y * 1.0f/*GameplayManager.Instance.OverallMouseSensitivity*/;

            currentYaw = (invertHorizontalAxis ? -axis.x : axis.x)
                * currentSensitivity.x * 1.0f/*GameplayManager.Instance.OverallMouseSensitivity*/;

            characterTargetRot *= Quaternion.Euler(0f, currentYaw, 0f);
            cameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

            if (m_LimitPitchRotation)
            {
                cameraTargetRot = ClampRotationAroundXAxis(cameraTargetRot, -maxPitch, -minPitch);
            }

            // ｽﾑｰｽいらないから消す
            if (smoothness > 0)
            {
                characterReference.localRotation = Quaternion.Slerp(characterReference.localRotation, characterTargetRot, 10 / smoothness * Time.deltaTime);
                cameraReference.localRotation = Quaternion.Slerp(cameraReference.localRotation, cameraTargetRot, 10 / smoothness * Time.deltaTime);
            }
            else
            {
                characterReference.localRotation = characterTargetRot;
                cameraReference.localRotation = cameraTargetRot;
            }
        }

        private Quaternion ClampRotationAroundXAxis(Quaternion q, float minimum, float maximum)
        {
            q.x /= q.w;
            q.y = 0;
            q.z = 0;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

            angleX = Mathf.Clamp(angleX, minimum, maximum);

            q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }
    }
}
