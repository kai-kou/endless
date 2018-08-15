using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class RocketAgent : Agent
{
    public GameObject explosionPrefab;
    public GameObject bulletPrefab;

    public override void InitializeAgent()
    {
        base.InitializeAgent();
    }

    public override void CollectObservations()
    {
        AddVectorObs(transform.position.x);
        AddVectorObs(transform.position.y);
        var rockCount = 1;
        foreach (var rock in GameObject.FindGameObjectsWithTag("Rock"))
        {
            AddVectorObs(rock.transform.position.x);
            AddVectorObs(rock.transform.position.y);
            AddVectorObs(rock.GetComponent<RockController>().endurance);
            
            if (rockCount++ >= 20)
            {
                break;
            }
        }
        for (int i = rockCount;i <= 20;i++)
        {
            AddVectorObs(0f);
            AddVectorObs(0f);
            AddVectorObs(0f);
        }
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
            var explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 2);
            GameObject.Find("Canvas").GetComponent<UIController>().AddScore(-10);
            AddReward(-0.1f);
            Done();
        }
    }

    public void MoveAgent(float[] act)
    {
        int action = Mathf.FloorToInt(act[0]);
        float speed = 0.2f;

        //アクション
        if (action==1)
        {
            transform.Translate(-1 * speed, 0, 0);
        }
        if (action==2)
        {
            transform.Translate(speed, 0, 0);
        }
        if (action==3)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            GameObject.Find("Canvas").GetComponent<UIController>().AddScore(-10);
        }

        if (transform.localPosition.x < -300f)
        {
            transform.localPosition =
                new Vector3(-300f, transform.localPosition.y, transform.localPosition.z);
        }
        else if (300f < transform.localPosition.x)
        {
            transform.localPosition =
                new Vector3(300f, transform.localPosition.y, transform.localPosition.z);
        }
    }

    public void Rocket_AddReward(float reward)
    {
        AddReward(reward);
        if (reward < 0)
        {
            Done();
        }
    }
}
