using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurretScript : MonoBehaviour {
	private float speed = 1000f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.x += Time.deltaTime * speed;
		transform.position = pos;
		if(pos.x > Screen.width) {
			Destroy(transform.gameObject);
		}
	}
}
