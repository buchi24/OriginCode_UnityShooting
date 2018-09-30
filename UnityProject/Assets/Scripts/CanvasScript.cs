using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {
	
	// 画面幅
	private int width = Screen.width;
	// 遠景画像Prefab
	public GameObject enkeiPrefab;
	// 遠景画像のインスタンス
	private GameObject enkeiInstance;
	// 近景画像Prefab
	public GameObject kinkeiPrefab;
	//近景画像インスタンス配列
	private GameObject[] kinkeis = new GameObject[2];
	//背景を流すSpeed
	//TODO: 外部設定変数に切り出す。
	private float speed = 100;

	//
	// ゲーム開始時に1度だけ呼ばれる関数（メソッド）
	//
	void Start () {	
		enkeiInstance = Instantiate(enkeiPrefab, new Vector3(0, 0, 0), Quaternion.identity);
		enkeiInstance.transform.SetParent(transform, false);

		width = width % 2 == 0 ? width : width + 1;
		float x = 0;
		for(int i = 0; i < kinkeis.Length; i++) {
			kinkeis[i] = Instantiate(kinkeiPrefab, new Vector3(x, 0, 0), Quaternion.identity);
			kinkeis[i].transform.SetParent(transform, false);
			x += width;
		}
	}
	
	///
	/// 毎フレーム呼ばれる関数（メソッド)
	///
	private float debugCount = 0;
	void Update () {
		for(int i = 0; i < kinkeis.Length; i++) {
			Vector3 pos = kinkeis[i].transform.position;
			GameObject otherObj = i == 0 ? kinkeis[1] : kinkeis[0];
			if(pos.x <= -(float)width / 2) pos.x = otherObj.transform.position.x + width;
			pos.x -= Time.deltaTime * speed;
			kinkeis[i].transform.position = pos;
		}
	}
}
