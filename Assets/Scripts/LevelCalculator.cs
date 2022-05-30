using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelCalculator : MonoBehaviour
{
    public static LevelCalculator Instance;

    [SerializeField] TextMeshProUGUI scoreText;
    public float score = 0f;
    public int usedBombCount = 0;
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

    void Update()
    {
        
    }

    public void PushScore()
    {
        scoreText.text = "Score : " + score.ToString();
    }
}
