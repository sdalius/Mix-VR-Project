using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    public float MinSpeed;
    private Vector3 previousBallPosition;
    private Rigidbody stopForce;
    private bool bOutOfBounds = false;
    void Start()
    {
        previousBallPosition = this.transform.position;
        stopForce = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if(stopForce.velocity.sqrMagnitude < MinSpeed && stopForce.velocity != Vector3.zero && !bOutOfBounds)
        {
            setLastPosition();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        var outOfBounds = collision.gameObject.GetComponent<OutOfBounds>();

        if(outOfBounds)
            setbOutOfBounds(true);
    }

    void setLastPosition()
    {
        stopForce.velocity = Vector3.zero;
        previousBallPosition = stopForce.transform.position;
    }

    void setbOutOfBounds(bool bOutOfBounds)
    {
        this.bOutOfBounds = bOutOfBounds;
    }
    public IEnumerator ResetToLastPosition(float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        if(stopForce.transform.position != previousBallPosition)
        {
            stopForce.transform.position = previousBallPosition;
            stopForce.velocity = Vector3.zero;
            setbOutOfBounds(false);
        }
    }
}
