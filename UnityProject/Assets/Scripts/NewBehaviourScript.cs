using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewBehaviourScript : MonoBehaviour {

	public Text textfield;
	private int count = 0;
	
	// Use this for initialization
	void Start () {
		textfield.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
	count = count + 1;
	Debug.Log(count);
	textfield.text = count.ToString();
		
	}
}
