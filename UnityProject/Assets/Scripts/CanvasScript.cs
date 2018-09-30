using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {
	
	private int width = Screen.width;
	private int height = Screen.height;

	public GameObject enkeiPrefab;
	private GameObject enkeiInstance;

	public GameObject kinkeiPrefab;
	private GameObject kinkeiInstance;
	private GameObject secondKinkeiInstance;
	private GameObject[] kinkeis = new GameObject[2];
	private float speed = 1f;


	//
	// ゲーム開始時に1度だけ呼ばれる関数（メソッド）
	//
	void Start () {
		Debug.Log(Screen.width + "," + Screen.height);
		enkeiInstance = Instantiate(enkeiPrefab, new Vector3(0, 0, 0), Quaternion.identity);

		kinkeiInstance = Instantiate(kinkeiPrefab, new Vector3(0, 0, 0), Quaternion.identity);
		secondKinkeiInstance = Instantiate(kinkeiPrefab, new Vector3(width, 0, 0), Quaternion.identity);

		kinkeis[0] = kinkeiInstance;
		kinkeis[1] = secondKinkeiInstance;

		enkeiInstance.transform.SetParent(transform, false);
		kinkeiInstance.transform.SetParent(transform, false);
		secondKinkeiInstance.transform.SetParent(transform, false);
	}
	
	///
	/// 毎フレーム呼ばれる関数（メソッド)
	///
	void Update () {
		foreach(GameObject kinkei in kinkeis) {
			Vector3 pos = kinkei.transform.position;
			if(pos.x <= -(float)width / 2) pos.x = (float)width * 1.5f;
			pos.x -= Time.deltaTime * 200;
			kinkei.transform.position = pos;
		}		
	}
}
