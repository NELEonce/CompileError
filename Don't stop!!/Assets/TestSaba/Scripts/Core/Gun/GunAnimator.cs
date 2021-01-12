using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStop.Weapons
{
    [System.Serializable, DisallowMultipleComponent]
    public sealed class GunAnimator
    {
        private Animator gunAnim;

        public void Init(Animator anim)
        {
            gunAnim = anim;
        }

        public void Fire()
        {
            gunAnim.Play("Fire", 0, 0.0f);
        }

        public void Reload()
        {
            gunAnim.Play("Reload", 0, 0.0f);
        }
    }
}
