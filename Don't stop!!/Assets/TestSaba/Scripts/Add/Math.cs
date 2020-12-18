using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStop.Math
{
    public class Math
    {
        /// <summary>
        /// Y軸の値を除く
        /// </summary>
        public static Vector3 EraseYAxis(Vector3 v)
        {
            return Vector3.Scale(v, new Vector3(1, 0, 1));
        }
    }
}
