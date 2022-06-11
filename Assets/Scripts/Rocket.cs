using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float radius = 5f;
    public float force = 700f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        Explode();
        Destroy(gameObject);
    }

    void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders) {
            // Add force
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddExplosionForce(force, transform.position, radius);
            }
            else {
                ImpactReceiver impactReceiver = nearbyObject.GetComponent<ImpactReceiver>();
                if (impactReceiver != null) {
                    Vector3 dir = nearbyObject.transform.position - transform.position;
                    impactReceiver.AddImpact(dir, force);
                }
            }

        }
    }
}
