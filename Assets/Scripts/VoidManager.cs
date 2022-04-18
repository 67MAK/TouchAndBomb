using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            Destroy(other.gameObject);
        }
    }
}
