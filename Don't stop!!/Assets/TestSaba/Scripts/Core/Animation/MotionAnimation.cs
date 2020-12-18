using UnityEngine;

namespace DontStop.Animation
{
    [System.Serializable, DisallowMultipleComponent]
    public sealed class MotionAnimation
    {
        [SerializeField]
        [Required]
        [Tooltip("動作に影響のあるｱﾆﾒｰｼｮﾝ用のtransform")]
        private Transform targetTransform;

        #region LEAN

        [SerializeField]
        [Range(0, 90)]
        [Tooltip("傾きの角度(壁走り)")]
        private float leanAngle = 5;

        [SerializeField]
        [Range(0.001f, 10)]
        [Tooltip("傾く速さ")]
        private float leanSpeed = 0.5f;

        #endregion

        private Vector3 leanEulerAngles = Vector3.zero;

        public void df()
        {

        }

        /// <summary>
        /// ｶﾒﾗの傾きｱﾆﾒｰｼｮﾝ
        /// </summary>
        public void LeanAnimation(DontStop.Player.LeanState directon)
        {
            if (directon == DontStop.Player.LeanState.Right)
            {
                leanEulerAngles = Vector3.Lerp(leanEulerAngles, new Vector3(0, 0, leanAngle), Time.deltaTime * leanSpeed);
            }
            else if (directon == DontStop.Player.LeanState.Left)
            {
                leanEulerAngles = Vector3.Lerp(leanEulerAngles, new Vector3(0, 0, -leanAngle), Time.deltaTime * leanSpeed);
            }
            else
            {
                leanEulerAngles = Vector3.Lerp(leanEulerAngles, Vector3.zero, Time.deltaTime * leanSpeed);
            }

            targetTransform.localEulerAngles = leanEulerAngles;
        }

        /// <summary>
        /// 最終的なﾘｰﾝの角度
        /// </summary>
        public Vector3 LeanFinalAngle(DontStop.Player.LeanState directon)
        {
            Vector3 ret = Vector3.zero;

            if (directon == DontStop.Player.LeanState.Right)
            {
                ret = new Vector3(0, 0, leanAngle);
            }
            else if (directon == DontStop.Player.LeanState.Left)
            {
                ret = new Vector3(0, 0, -leanAngle);
            }
            else
            {
                ret = Vector3.zero;
            }

            return ret;
        }
    }
}
