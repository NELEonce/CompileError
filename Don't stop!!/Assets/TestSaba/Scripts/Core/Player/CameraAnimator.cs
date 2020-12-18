using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel.Design;
using DontStop.Animation;

namespace DontStop.Player
{
    [DisallowMultipleComponent]
    public class CameraAnimator : MonoBehaviour
    {
        [SerializeField]
        [Required]
        [Tooltip("ﾌﾟﾚｲﾔ-のｽｸﾘﾌﾟﾄを参照")]
        private FPCharacterController fPCharacterController;

        /// <summary>
        /// 動きによるｱﾆﾒｰｼｮﾝ処理
        /// </summary>
        [SerializeField]
        [Tooltip("動きによるｱﾆﾒｰｼｮﾝ処理")]
        private MotionAnimation motionAnimation = new MotionAnimation();

        private void Update()
        {
            if (CanLean(Vector3.right * (int)fPCharacterController.leanState))
            {
                motionAnimation.LeanAnimation(fPCharacterController.leanState);
            }
        }

        // ﾘｰﾝできるか
        private bool CanLean(Vector3 direction)
        {
            Ray ray = new Ray(fPCharacterController.transform.position, fPCharacterController.transform.TransformDirection(direction));
            return !Physics.SphereCast(ray, 0.2f, out _, 0.2f * 2, Physics.AllLayers, QueryTriggerInteraction.Ignore);
        }

        public Vector3 TransformLeanUp()
        {
            return Quaternion.Euler(motionAnimation.LeanFinalAngle(fPCharacterController.leanState)) * Vector3.up;
        }
    }
}
