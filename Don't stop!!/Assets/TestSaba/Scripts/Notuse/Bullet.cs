using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

namespace DontStop.Weapons.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("ｴﾌｪｸﾄ")]
        private GameObject hibana;

        [SerializeField]
        [Tooltip("弾速")]
        private float speed = 1f;

        [SerializeField]
        [Tooltip("弾速に比例した飛び散りの力")]
        private float powerMultiplier = 1f;

        void Update()
        {
            var oldPos = transform.position;
            transform.position += transform.forward * speed * Time.deltaTime;

            var maxDistance = Vector3.Distance(oldPos, transform.position);

            if (Physics.Raycast(oldPos, transform.forward, out RaycastHit hitInfo, maxDistance))
            {
                var dir = transform.rotation * Quaternion.Euler(0, 180.0f, 0);
                Instantiate(hibana, hitInfo.point, dir);
                if (hitInfo.transform.tag == "Break")
                {
                    hitInfo.transform.GetComponent<Explode>().StartExplode(hitInfo.point, speed * powerMultiplier);
                }
                Destroy(gameObject);
            }

            Invoke("LifeLimit", 3);
        }

        void LifeLimit()
        {
            Destroy(gameObject);
        }
    }
}
