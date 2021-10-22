using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    [SerializeField]
    float collisionTimeTolerance = 0.5f;

    private ScoreTracker scoreTracker;
    private float lastHitTime;
    // Start is called before the first frame update
    void Start()
    {
        scoreTracker = FindObjectOfType<ScoreTracker>();
        lastHitTime = Time.realtimeSinceStartup;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var ball = collision.gameObject.GetComponent<Ball>();

        if(ball)
        {
            //Avoid multiple collisions with one strike
            if(lastHitTime < Time.time - collisionTimeTolerance)
            {
                IncrementScore();
            }
        }
    }

    private void IncrementScore()
    {
        scoreTracker.IncrementScore();
        lastHitTime = Time.time;
    }
}
