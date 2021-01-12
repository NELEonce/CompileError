using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField]
    [Tooltip("半径")]
    private float rad = 10;

    [SerializeField]
    [Range(0, 10)]
    [Tooltip("重力加速度を変更")]
    private float gravityMultiplier = 1;

    [SerializeField]
    [Tooltip("ﾄﾙｸ")]
    private Vector3 trque;

    private bool exploded;

    private void Start()
    {
        exploded = false;
    }
    
    private void FixedUpdate()
    {
        if (exploded == true)
        {
            foreach (Transform t in transform)
            {
                var rb = t.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    var gravity = Physics.gravity * gravityMultiplier;
                    rb.AddForce(gravity, ForceMode.Acceleration);
                }
            }
        }
    }

    /// <summary>
    /// powerMultiplier
    /// </summary>
    /// <param name="expPos">爆発の中心</param>
    /// <param name="power">威力</param>
    public void StartExplode(Vector3 expPos, float power)
    {
        exploded = true;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;

        foreach (Transform t in transform)
        {
            t.gameObject.AddComponent<Rigidbody>();
            var rb = t.GetComponent<Rigidbody>();
            
            if (rb != null)
            {
                rb.AddExplosionForce(power, expPos, rad);
                rb.AddTorque(new Vector3(Random.Range(-trque.x, trque.x), Random.Range(-trque.y, trque.y), Random.Range(-trque.z, trque.z))
                    , ForceMode.Impulse);
            }
        }

        Invoke("LifeLimit", 4);
    }

    private void LifeLimit()
    {
        Destroy(gameObject);
    }
}
