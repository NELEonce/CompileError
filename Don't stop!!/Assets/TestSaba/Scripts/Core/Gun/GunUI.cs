using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStop.Weapons.UI
{
    [System.Serializable]
    public class GunUI
    {
        private GameObject reticle;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Init()
        {
            reticle = GameObject.Find("Reticle");

            if (reticle != null)
            {
                reticle.SetActive(false);
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            if (reticle != null)
            {
                if (Time.timeScale == 0)
                {
                    reticle.SetActive(false);
                }
                else
                {
                    reticle.SetActive(true);
                }
            }
        }
    }
}
