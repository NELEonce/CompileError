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

        [SerializeField]
        [Tooltip("銃のUI")]
        private UI.GunUI gunUI = new UI.GunUI();

        [SerializeField]
        private Transform ejectorPoint;

        [SerializeField]
        [Required]
        [Tooltip("弾")]
        private GameObject bullet;

        private Controller1.GunActions gunController;

        private void Awake()
        {
            if (!gunData)
            {
                throw new Exception("GunDataが割り当てられてないっす");
            }

            gunController = new Controller1().Gun;

            // ｺｰﾙﾊﾞｯｸの登録
            gunController.Shoot.started += _ => Shoot();
            gunController.Reload.started += _ => Reload();
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
            gunUI.Init();
            gunAnimator.Init(GetComponent<Animator>());
        }

        void Update()
        {
            gunUI.Update();
        }

        #region INPUTREGISTER

        private void Shoot()
        {
            Instantiate(bullet, ejectorPoint.position, ejectorPoint.rotation);
            gunAnimator.Fire();
        }

        private void Reload()
        {
            gunAnimator.Reload();
        }

        #endregion
    }
}
