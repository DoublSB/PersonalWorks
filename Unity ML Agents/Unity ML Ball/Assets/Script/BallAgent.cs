using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using UnityEngine.UI;

public class BallAgent : Agent
{
    private Rigidbody ballRigidbody;
    public Transform pivotTransform;
    public Transform target; //아이템 목표 위치

    public Text Score;

    public float moveForce = 10f;

    private bool isTargetEaten = false;
    private bool isdead = false;

    private void Awake()
    {
        ballRigidbody = GetComponent<Rigidbody>();
    }

    private void ResetTarget()
    {
        isTargetEaten = false;
        Vector3 rdpos = new Vector3(Random.Range(-5f, 5f), 0.5f, Random.Range(-5f, 5f));
        target.position = rdpos + pivotTransform.position; //굳이?
    }

    public override void AgentReset()
    {
        Vector3 rdpos = new Vector3(Random.Range(-5f, 5f), 0.5f, Random.Range(-5f, 5f));
        transform.position = rdpos + pivotTransform.position;

        isdead = false;
        ballRigidbody.velocity = Vector3.zero;

        ResetTarget();
    }

    public override void CollectObservations()
    {
        Vector3 distanceToTarget = target.position - transform.position;

        //+-5를 +-1로 정규화해서 제공해야 퍼포먼스가 올라간다
        AddVectorObs(Mathf.Clamp(distanceToTarget.x / 5f, -1f, 1f));
        AddVectorObs(Mathf.Clamp(distanceToTarget.z / 5f, -1f, 1f));

        Vector3 relativePos = transform.position - pivotTransform.position;

        AddVectorObs(Mathf.Clamp(relativePos.x / 5f, -1f, 1f));
        AddVectorObs(Mathf.Clamp(relativePos.z / 5f, -1f, 1f));

        //+-10 -> +-1
        AddVectorObs(Mathf.Clamp(ballRigidbody.velocity.x / 10f, -1f, 1f));
        AddVectorObs(Mathf.Clamp(ballRigidbody.velocity.z / 10f, -1f, 1f));
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        AddReward(-0.001f);

        float horizontalInput = vectorAction[0];
        float verticalInput = vectorAction[1];

        ballRigidbody.AddForce(horizontalInput * moveForce, 0f, verticalInput * moveForce);

        if (isTargetEaten)
        {
            AddReward(1.0f);
            ResetTarget();
        }
        else if (isdead)
        {
            AddReward(-1.0f);
            Done();
        }

        Monitor.Log(name, GetCumulativeReward(), transform);
        Score.text = GetCumulativeReward().ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("dead"))
        {
            isdead = true;
        }
        else if (other.CompareTag("goal"))
        {
            isTargetEaten = true;
        }
    }
}
