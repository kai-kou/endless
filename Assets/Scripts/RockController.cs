using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour {

	float fallSpeed;
	float rotSpeed;
	public float endurance;

	// Use this for initialization
	void Start () {
		this.fallSpeed = (0.01f + 0.01f * Random.value) * Time.timeScale;
		this.rotSpeed = (5f + 3f * Random.value) * Time.timeScale;
		this.endurance = 1f + Random.value * 5f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, -fallSpeed, 0, Space.World);
		transform.Rotate(0, 0, rotSpeed);

		if (transform.position.y < -5.5f) {
			Destroy (gameObject);
			GameObject.Find("Canvas").GetComponent<UIController>().AddScore(-5000);
			GameObject.Find("Rocket").GetComponent<RocketAgent>().Rocket_AddReward(-5f);
		}
	}

	public float Crash()
	{
		return this.endurance--;
	}
}
