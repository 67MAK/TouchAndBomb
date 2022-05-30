using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] GameObject[] _objects;
    [SerializeField] GameObject playerPlane, explosionEffect, inGameScreen, endLevelScreen, isDeadScreen;
    bool noObjectLeft = false;
    int countObject = 0;
    public bool isDead = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LevelCalculator.Instance.PushScore();
    }

    public void CheckObjects()
    {
        for(int i = 0; i < _objects.Length; i++)
        {
            if (_objects[i] != null)
            {
                countObject++;
            }
        }
        Debug.Log("Object Left : " + countObject);
        if (countObject <= 1)
        {
            noObjectLeft = true;
            EndLevel();
        }
        else
        {
            countObject = 0;
        }
    }
    void EndLevel()
    {
        inGameScreen.SetActive(false);
        endLevelScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void IsDeadProcess()
    {
        GameObject _exp = Instantiate(explosionEffect, playerPlane.transform.position, Quaternion.identity);
        Destroy(_exp, 3);
        isDeadScreen.SetActive(true);
        inGameScreen.SetActive(false);
        CameraController.Instance.CamBehavWhenDead();
        playerPlane.GetComponent<PlaneController>().enabled = false;
        playerPlane.GetComponent<Rigidbody>().velocity = Vector3.zero;
        playerPlane.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
