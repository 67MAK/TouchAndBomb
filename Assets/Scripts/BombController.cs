using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] GameObject _explosion;
    [SerializeField] float _radius, _expForce;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Object"))
        {
            GameObject _exp = Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(_exp, 3);
            expEffect();
            Destroy(gameObject);
        }
    }

    void expEffect()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider nearBy in colliders)
        {
            Rigidbody nearRB = nearBy.GetComponent<Rigidbody>();
            if (nearRB != null)
            {
                nearRB.AddExplosionForce(_expForce, transform.position, _radius);
            }
        }
    }
}
