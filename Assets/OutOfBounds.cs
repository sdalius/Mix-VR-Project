using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField]
    float waitTimeForReset = 2.0f;
    private float lastHitTime;
    // Start is called before the first frame update

    void Start()
    {
        lastHitTime = Time.realtimeSinceStartup;
    }
    void OnCollisionEnter(Collision collision)
    {
        var ball = collision.gameObject.GetComponent<Ball>();

        if(ball)
        {
            //Avoid multiple collisions with one strike
            if(lastHitTime < Time.time - waitTimeForReset)
            {
                ball.ResetToLastPosition();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
