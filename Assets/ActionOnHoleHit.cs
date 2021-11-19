using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionOnHoleHit : MonoBehaviour
{
    // Start is called before the first frame update

    private ScoreTracker savethis;
    void Start()
    {
        savethis = FindObjectOfType<ScoreTracker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<Ball>();

        if(ball)
        {
            SceneManager.LoadScene("Level 2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
