using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
    //Serialized for debugging
    [SerializeField]
    float levelScore = 0;

    private ScoreTracker scoreBoard;
    //Serialized for debugging
    [SerializeField]
    float totalScore = 0;

    private GameObject[] currentScores;
    private GameObject[] totalScores;
    private int i;
    


    void Awake()
    { ;
        //Add on scene loaded listener
        SceneManager.sceneLoaded -= OnSceneLoaded;
        //Add on scene loaded listener
        SceneManager.sceneLoaded += OnSceneLoaded;
        //Reset level score
        levelScore = 0;
        DontDestroyOnLoad(transform.root.gameObject);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentScores = GameObject.FindGameObjectsWithTag("Level Score");
        totalScores = GameObject.FindGameObjectsWithTag("Total Score");
        var levelName = GameObject.FindGameObjectWithTag("LevelName").GetComponent<TextMeshProUGUI>();
        var holenum = GameObject.FindGameObjectWithTag("HoleTitle").GetComponent<TextMeshProUGUI>();
        var getTextOfCurrScore = GameObject.FindGameObjectWithTag("Level Score").GetComponent<TextMeshProUGUI>();

        getTextOfCurrScore.text = "Level Score: 0";
        holenum.text = "Hole Nr. " + ++i;
        
        if (SceneManager.GetActiveScene().name == "Level 2")
        { 
            transform.position = new Vector3(-1, float.Parse("0.7"), float.Parse("-4.30000019"));
            transform.rotation = new Quaternion(0, 0, 0, 0);
            levelScore = 0;
        }
        

        if (levelName)
        {
            levelName.text = SceneManager.GetActiveScene().name;
        }

        if(currentScores.Length == 0)
        {
            Debug.LogWarning("No current scores found");
        }

        if(totalScores.Length == 0)
        {
            Debug.LogWarning("No total scores found");
        }
    }

    internal void IncrementScore()
    {
        UpdateLevelScore();
        UpdateTotalScore();

        if(levelScore >= 12)
        {
            //Move on to the next level
        }
    }

    private void UpdateTotalScore()
    {
        totalScore++;
        
            foreach (GameObject score in totalScores)
            {
                var text = score.GetComponent<TextMeshProUGUI>();
                text.text = "Total Score: " + totalScore;
            }
    }

    private void UpdateLevelScore()
    {
        levelScore++;
        foreach (GameObject score in currentScores)
            {
                var text = score.GetComponent<TextMeshProUGUI>();
                text.text = "Level Score: " + levelScore;
            }
    }
}
