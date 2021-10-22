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
    //Serialized for debugging
    [SerializeField]
    float totalScore = 0;

    private GameObject[] currentScores;
    private GameObject[] totalScores;


    void Awake()
    {
        //Remove listener to avoid duplicate listeners - Safe to remove even if it doesn't exist
        SceneManager.sceneLoaded -= OnSceneLoaded;
        //Add on scene loaded listener
        SceneManager.sceneLoaded += OnSceneLoaded;

        //Reset level score
        levelScore = 0;

        DontDestroyOnLoad(this.gameObject);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentScores = GameObject.FindGameObjectsWithTag("Level Score");
        totalScores = GameObject.FindGameObjectsWithTag("Total Score");

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
            text.text = "Total: " + totalScore;
        }
    }

    private void UpdateLevelScore()
    {
        levelScore++;

        foreach (GameObject score in currentScores)
        {
            var text = score.GetComponent<TextMeshProUGUI>();
            text.text = "Level: " + levelScore;
        }
    }
}
