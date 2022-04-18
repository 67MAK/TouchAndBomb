using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject[] _objects;
    [SerializeField] GameObject _inGameScreen, _endLevelScreen;
    bool noObjectLeft = false;
    int countObject = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckObjects();
        if(noObjectLeft)
            EndLevel();
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
        if(countObject == 0)
        {
            noObjectLeft = true;
        }
        else
        {
            countObject = 0;
        }
    }
    void EndLevel()
    {
        _inGameScreen.SetActive(false);
        _endLevelScreen.SetActive(true);
        Time.timeScale = 0;
    }
}