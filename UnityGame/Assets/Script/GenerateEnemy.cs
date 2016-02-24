using UnityEngine;
using System.Collections;

public class GenerateEnemy : MonoBehaviour {
	public GameObject obj;
	private GameObject enemy;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Generate",0,3.0f);
	}

	// Update is called once per frame
	void Update () {
	}

	void Generate(){
		if (!enemy) {
			enemy = Instantiate (obj);
			float x = Random.Range (1, 50) / 10;
			float z = Random.Range (1, 50) / 10;
			Vector3 pos = new Vector3 (x, 0, z);
			enemy.transform.position = pos;
		} else {
			if (!enemy.activeInHierarchy) {
				Destroy (enemy);
				enemy = null;
			}
		}
	}
}
