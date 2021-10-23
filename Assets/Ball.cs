using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    [SerializeField]
    public float MinSpeed;
    private Vector3 previousBallPosition;
    private Rigidbody stopForce;
    void Start()
    {
        previousBallPosition = this.transform.position;
        stopForce = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(((stopForce.velocity.sqrMagnitude < MinSpeed) && stopForce.velocity != Vector3.zero))
        {
            setLastPosition();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
    }

    void setLastPosition()
    {
        stopForce.velocity = Vector3.zero;
        previousBallPosition = stopForce.transform.position;
    }

    public void ResetToLastPosition()
    {
        if(stopForce.transform.position != previousBallPosition)
        {
            stopForce.transform.position = previousBallPosition;
            stopForce.velocity = Vector3.zero;
        }
    }
}
