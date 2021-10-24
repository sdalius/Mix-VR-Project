using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField]
    float waitTimeForReset;
    private float lastHitTime;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        var ball = collision.gameObject.GetComponent<Ball>();

        if(ball)
        {
            StartCoroutine(ball.ResetToLastPosition(waitTimeForReset));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
