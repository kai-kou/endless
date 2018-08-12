using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class RocketAgent : Agent
{
    public float speed;
    public GameObject Rocket;
    public GameObject explosionPrefab;

    public override void InitializeAgent()
    {
        base.InitializeAgent();
    }

    public override void CollectObservations()
    {
        AddVectorObs(Rocket.transform.position.x);
        Debug.Log(Rocket.transform.position.x);
    }

    /// <summary>
    /// In the editor, if "Reset On Done" is checked then AgentReset() will be 
    /// called automatically anytime we mark done = true in an agent script.
    /// </summary>
	public override void AgentReset()
    {
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        MoveAgent(vectorAction);
    }
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Rock")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            AddReward(-1f);
            Done();
        }
    }

    public void MoveAgent(float[] act)
    {
        int action = Mathf.FloorToInt(act[0]);

        //アクション
        if (action==1)
        {
            transform.Translate (-0.1f, 0, 0);
            AddReward(0.1f);
        }
        if (action==2)
        {
            transform.Translate (0.1f, 0, 0);
            AddReward(0.1f);
        }

        if (transform.localPosition.x < -2f)
        {
            transform.localPosition =
                new Vector3(-2f, transform.localPosition.y, transform.localPosition.z);
        }
        if (2f < transform.localPosition.x)
        {
            transform.localPosition =
                new Vector3(2f, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
