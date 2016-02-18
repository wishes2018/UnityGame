﻿using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;

public class Test : MonoBehaviour {

	public GameObject bullet;
	public GameObject wave;
	public Transform shootTrans;
	public float warnRange;
	private BehaviorTree tree;
	private SharedBool hasEnemy;
	private SharedGameObject enemy;

	// Use this for initialization
	void Start () {
		tree = GetComponent<BehaviorTree> ();
		hasEnemy = (SharedBool)tree.GetVariable ("hasEnemy");
		enemy = (SharedGameObject)tree.GetVariable ("enemy");
	}
	
	// Update is called once per frame
	void Update () {
		Collider[] colliders= Physics.OverlapSphere (transform.position,warnRange);
		if (colliders.Length > 1) {
			hasEnemy.Value = true;
			enemy.Value = colliders [1].gameObject;
		}
	}

	public void fire(){
		GameObject s1 = (GameObject)Instantiate(bullet, shootTrans.position, transform.rotation);
		s1.GetComponent<BeamParam>().SetBeamParam(GetComponent<BeamParam>());

		GameObject wav = (GameObject)Instantiate(wave, shootTrans.position, shootTrans.rotation);
		wav.transform.localScale *= 0.25f;
		wav.transform.Rotate(Vector3.left, 90.0f);
		wav.GetComponent<BeamWave>().col = GetComponent<BeamParam>().BeamColor;
	}
}
