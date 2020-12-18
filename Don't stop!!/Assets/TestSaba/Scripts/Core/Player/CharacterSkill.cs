using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStop.Player.Skill
{
    [DisallowMultipleComponent, System.Serializable]
    public class CharacterSkill
    {
        #region SKILL

        [SerializeField]
        [Range(0, 1)]
        [Tooltip("時間の進む速さ")]
        private float chronostasisScale = 0.5f;

        [SerializeField]
        [Range(0, 20)]
        [Tooltip("指定したｽｹｰﾙになる速さ")]
        private float chronostasisScaleSpeed = 1;

        #endregion

        /// <summary>
        /// 時間を操作するｽｷﾙのﾌﾗｸﾞ
        /// </summary>
        [System.NonSerialized]
        public bool chronostasis = false;

        /// <summary>
        /// 時間の流れを操る
        /// </summary>
        public void UpdateChronostasis()
        {
            if (chronostasis && !Mathf.Approximately(Time.timeScale, chronostasisScale))
            {
                Time.timeScale = Mathf.Lerp(Time.timeScale, chronostasisScale, Time.deltaTime * chronostasisScaleSpeed);
            }
            else if (!Mathf.Approximately(Time.timeScale, 1))
            {
                Time.timeScale = Mathf.Lerp(Time.timeScale, 1, Time.deltaTime * chronostasisScaleSpeed);
            }
        }
    }
}
