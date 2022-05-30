using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoidManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Object") && SceneManager.GetActiveScene().buildIndex == 1)
        {
            Destroy(other.gameObject);
            LevelCalculator.Instance.score += 50f;
            LevelManager.Instance.CheckObjects();
        }
        else
        {
            Destroy (other.gameObject);
        }
    }
}
