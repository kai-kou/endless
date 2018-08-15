using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public GameObject explosionPrefab;   //爆発エフェクトのPrefab

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, 0.2f * Time.timeScale, 0);
		if (transform.position.y > 5f) {
			Destroy(this.gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Rock")
		{
			var rock = coll.gameObject.GetComponent<RockController>();
			if (rock.Crash() <= 0)
			{
				// 爆発エフェクトを生成する	
				var explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
				Destroy(explosion, 2);
				Destroy(coll.gameObject);
				GameObject.Find("Canvas").GetComponent<UIController>().AddScore(100);
				GameObject.Find("Rocket").GetComponent<RocketAgent>().Rocket_AddReward(1f);
			}

			Destroy(this.gameObject);

			// 衝突したときにスコアを更新する
			GameObject.Find("Canvas").GetComponent<UIController>().AddScore(10);
			GameObject.Find("Rocket").GetComponent<RocketAgent>().Rocket_AddReward(0.1f);
		}
	}
}
