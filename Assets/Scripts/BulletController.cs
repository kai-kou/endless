﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public GameObject explosionPrefab;   //爆発エフェクトのPrefab

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, 0.2f, 0);
		if (transform.position.y > 5) {
			Destroy(this.gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Rock")
		{
			// 爆発エフェクトを生成する	
			Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			Destroy(coll.gameObject);
			Destroy(this.gameObject);

			// 衝突したときにスコアを更新する
			GameObject.Find("Canvas").GetComponent<UIController>().AddScore(10);
			GameObject.Find("RocketAgent").GetComponent<RocketAgent>().AddReward();
		}
	}
}
