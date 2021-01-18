using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.Attributes;

namespace DontStop.Weapons
{
    [CreateAssetMenu(menuName = "GunData", fileName = "GunData")]
    public sealed class GunData : ScriptableObject
    {
        // 弾薬やリロードのタイミング、サウンド、エフェクト、レート、照準、ズームアップ
        
        /// <summary>
        /// マガジンが無限かどうか
        /// </summary>
        [SerializeField]
        [Tooltip("マガジンが無限かどうか")]
        private bool magazineInfinite = true;
        public bool GetMagazineInfinite() { return magazineInfinite; }

        /// <summary>
        /// ﾏｶﾞｼﾞﾝごとの弾数
        /// </summary>
        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("ﾏｶﾞｼﾞﾝごとの弾数")]
        private int bulletsPerMagazine = 6;
        public int GetBulletsPerMagazine() { return bulletsPerMagazine; }

        /// <summary>
        /// 所持弾数
        /// </summary>
        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("所持弾数")]
        private int maxBullets = 100;
        public int GetMaxBullets() { return maxBullets; }

        /// <summary>
        /// 射撃ﾚｰﾄ
        /// </summary>
        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("射撃ﾚｰﾄ")]
        private float shootingRate = 0.2f;
        public float GetShootingRate() { return shootingRate; }

        /// <summary>
        /// ｽﾞｰﾑ倍率
        /// </summary>
        [SerializeField]
        [Range(0, 10)]
        [Tooltip("ｽﾞｰﾑ倍率")]
        private float zoomPower = 1;
        public float GetZoomPower() { return zoomPower; }

        /// <summary>
        /// ﾘﾛｰﾄﾞが始まって撃てるようになるまでの時間
        /// </summary>
        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("ﾘﾛｰﾄﾞが始まって撃てるようになるまでの時間")]
        private float reloadCompleteTime = 1;
        public float GetReloadCompleteTime() { return reloadCompleteTime; }
    }
}
