using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStop.Player.VFX
{
    [DisallowMultipleComponent, System.Serializable]
    public class CharacterVFX
    {
        #region SPEEDLINE

        [SerializeField]
        [Required]
        [Tooltip("ｽﾋﾟｰﾄﾞ線ﾌﾟﾚﾊﾌﾞ")]
        private GameObject speedLine;

        [SerializeField]
        [Range(0, 200)]
        [Tooltip("線の最大出現速度")]
        private float speedLineDefaultRate = 100;

        [SerializeField]
        [Tooltip("ｽﾋﾟｰﾄﾞ線ｴﾌｪｸﾄのﾌﾟﾚｲﾔｰからの距離")]
        private float speedLineDefaultPos;

        [SerializeField]
        [Range(0, 50)]
        [Tooltip("線が出現する最小速度")]
        private float minSpeed = 3;

        [SerializeField]
        [Range(0, 50)]
        [Tooltip("線の出現量が最大になる速度")]
        private float maxSpeed = 20;

        [SerializeField]
        [Range(10, 100)]
        [Tooltip("線の減少速度")]
        private float decrease = 20;

        #endregion

        private ParticleSystem speedLinePS;

        public void EffectInit(Transform parent)
        {
            speedLine = GameObject.Instantiate(speedLine);
            speedLine.transform.parent = parent;
            speedLine.transform.localEulerAngles = parent.eulerAngles;
            speedLine.transform.localPosition = parent.forward * speedLineDefaultPos;
            speedLinePS = speedLine.transform.GetComponent<ParticleSystem>();
            speedLine.SetActive(false);
            
        }

        /// <summary>
        /// ｽﾋﾟｰﾄﾞ線
        /// </summary>
        /// <param name="run"></param>
        public void SpeedLine(float vel)
        {
            
            var emission = speedLinePS.emission;
            Debug.Log((Mathf.Min(vel, maxSpeed) / maxSpeed));

            if (vel >= minSpeed)
            {
                if (!speedLine.activeSelf)
                {
                    speedLine.SetActive(true);
                }
                else
                {
                    emission.rateOverTime = (Mathf.Min(vel, maxSpeed) / maxSpeed) * speedLineDefaultRate;
                }
            }
            else
            {
                emission.rateOverTime = 0;
                
                if (speedLinePS.particleCount <= 0)
                {
                    speedLine.SetActive(false);
                }
            }
        }
    }
}
