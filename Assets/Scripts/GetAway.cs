using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAway : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody collisionRB = collision.gameObject.GetComponent<Rigidbody>();
        if (collisionRB != null)
        {
            collisionRB.AddExplosionForce(900f, transform.position, 20f);
        }
    }
}
