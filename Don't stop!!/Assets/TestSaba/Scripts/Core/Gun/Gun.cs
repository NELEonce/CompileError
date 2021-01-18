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
        private float rateTime;
        private int remainingRounds;
        private float reloadTime;

        private void Awake()
        {
            if (!gunData)
            {
                throw new Exception("GunDataが割り当てられてないよ");
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

            rateTime = gunData.GetShootingRate();
            reloadTime = gunData.GetReloadCompleteTime();
            remainingRounds = gunData.GetBulletsPerMagazine();
        }

        void Update()
        {
            gunUI.Update();
            var i = GetComponent<Collider>();
            
            if (rateTime <= gunData.GetShootingRate()) rateTime += Time.deltaTime;
            if (reloadTime <= gunData.GetReloadCompleteTime()) reloadTime += Time.deltaTime;
        }

        #region INPUTREGISTER

        private void Shoot()
        {
            if (remainingRounds > 0 && rateTime >= gunData.GetShootingRate() && reloadTime >= gunData.GetReloadCompleteTime())
            {
                Instantiate(bullet, ejectorPoint.position, ejectorPoint.rotation);
                gunAnimator.Fire();
                remainingRounds -= 1;
                rateTime = 0;
            }
        }

        private void Reload()
        {
            if (remainingRounds < gunData.GetBulletsPerMagazine())
            {
                gunAnimator.Reload();
                remainingRounds = gunData.GetBulletsPerMagazine();
                reloadTime = 0;
            }
        }

        #endregion
    }
}
