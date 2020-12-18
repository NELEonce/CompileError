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
        /// ﾏｶﾞｼﾞﾝが無限か有限か
        /// </summary>
        [SerializeField]
        [Tooltip("ﾏｶﾞｼﾞﾝが無限か有限か")]
        public bool MagazineInfinite = true;

        /// <summary>
        /// ﾏｶﾞｼﾞﾝごとの弾数
        /// </summary>
        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("ﾏｶﾞｼﾞﾝごとの弾数")]
        private int BulletsPerMagazine = 6;

        /// <summary>
        /// 所持弾数
        /// </summary>
        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("所持弾数")]
        private int MaxBullets = 100;

        /// <summary>
        /// 射撃ﾚｰﾄ
        /// </summary>
        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("射撃ﾚｰﾄ")]
        private float ShootingRate = 0.2f;

        /// <summary>
        /// ｽﾞｰﾑ倍率
        /// </summary>
        [SerializeField]
        [Range(0, 10)]
        [Tooltip("ｽﾞｰﾑ倍率")]
        private float zoomPower = 1;

        /// <summary>
        /// ﾘﾛｰﾄﾞが始まって撃てるようになるまでの時間
        /// </summary>
        [SerializeField]
        [MinMaxRange(0, Mathf.Infinity)]
        [Tooltip("ﾘﾛｰﾄﾞが始まって撃てるようになるまでの時間")]
        private float reloadTime = 1;
    }
}
