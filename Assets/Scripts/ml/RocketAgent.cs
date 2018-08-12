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
    public GameObject bulletPrefab;

    public override void InitializeAgent()
    {
        base.InitializeAgent();
    }

    public override void CollectObservations()
    {
        AddVectorObs(Rocket.transform.position.x);
    }

    /// <summary>
    /// In the editor, if "Reset On Done" is checked then AgentReset() will be 
    /// called automatically anytime we mark done = true in an agent script.
    /// </summary>
	public override void AgentReset()
    {
        // transform.localPosition = new Vector3(0, -4, 10f);
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
            AddReward(-10f);
            GameObject.Find("Canvas").GetComponent<UIController>().AddScore(-10);
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
        }
        if (action==2)
        {
            transform.Translate (0.1f, 0, 0);
        }
        if (action==3)
        {
            Instantiate (bulletPrefab, transform.position, Quaternion.identity);
        }

        if (transform.localPosition.x < -2.5f)
        {
            transform.localPosition =
                new Vector3(-2.5f, transform.localPosition.y, transform.localPosition.z);
            AddReward(-1f);
            Done();
        }
        else if (2.5f < transform.localPosition.x)
        {
            transform.localPosition =
                new Vector3(2.5f, transform.localPosition.y, transform.localPosition.z);
            AddReward(-1f);
            Done();
        }
        else {
            AddReward(1f);
        }
    }

    public void AddReward()
    {
        AddReward(10f);
    }
}
