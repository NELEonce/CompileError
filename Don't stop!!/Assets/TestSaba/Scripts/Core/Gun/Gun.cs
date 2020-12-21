using System;
using UnityEngine;

namespace DontStop.Weapons
{
    public class Gun : MonoBehaviour
    {
        [SerializeField]
        [Required]
        [Tooltip("武器に個別のﾊﾟﾗﾒｰﾀを与える")]
        private GunData gunData;

        [SerializeField]
        [Tooltip("動きによるｱﾆﾒｰｼｮﾝ処理")]
        private Animation.MotionAnimation motionAnimation = new Animation.MotionAnimation();

        [SerializeField]
        [Tooltip("銃のｱﾆﾒｰｼｮﾝ処理")]
        private GunAnimator gunAnimator = new GunAnimator();

        private Controller1.GunActions gunController;

        private void Awake()
        {
            if (!gunData)
            {
                throw new Exception("GunDataが割り当てられてないっす");
            }

            gunController = new Controller1().Gun;

            // ｺｰﾙﾊﾞｯｸの登録
            gunController.Aim.started += _ => Aim();
        }

        private void OnEnable()
        {
            gunController.Enable();
        }

        private void OnDisable()
        {
            gunController.Disable();
        }

        void Start()
        {

        }

        void Update()
        {

        }

        private void Aim()
        {

        }
    }
}
