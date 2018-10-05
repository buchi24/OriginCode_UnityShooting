using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {
	
	// 画面幅
	private int width = Screen.width;
	// 画面高さ
	private int height = Screen.height;
	// 遠景画像Prefab
	public GameObject enkeiPrefab;
	// 遠景画像のインスタンス
	private GameObject enkeiInstance;
	// 近景画像Prefab
	public GameObject kinkeiPrefab;
	//近景画像インスタンス配列
	private GameObject[] kinkeis = new GameObject[2];

	//キャラクター画像prefab
	public GameObject characterPrefab;
	//private float[] positionRatios = {0.6875f, 0.75f, 0.8215f};
	private float[] positionRatios = {0.6875f, 0.65f, 0.6215f};
	private GameObject characterInstance;
	int currentPos = -1;
	float diff = 45f / 720f;
	float posDiff = -1;
	//背景を流すSpeed
	//TODO: 外部設定変数に切り出す。
	private float speed = 100;

	public GameObject burretPrefab;

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

		float charaY = (height / 2);
		charaY -= height * positionRatios[0];
	
		
		characterInstance = Instantiate(characterPrefab, new Vector3(characterPrefab.GetComponent<RectTransform>().sizeDelta.x / 2, charaY, 0), Quaternion.identity);
		characterInstance.transform.SetParent(transform, false);

		Vector2 charaSize = characterInstance.GetComponent<RectTransform>().sizeDelta;
		charaSize.y = height / 3;
		charaSize.x = charaSize.y / 4 * 5;
		characterInstance.GetComponent<RectTransform>().sizeDelta = charaSize;

		currentPos = 0;

		posDiff = height * diff;
	}
	
	///
	/// 毎フレーム呼ばれる関数（メソッド)
	///
	void Update () {
		updateBackground();
		inputListen();
		updateSpeed();
	}

	///
	/// 背景を動かすメソッド。
	///
	private void updateBackground() {
		for(int i = 0; i < kinkeis.Length; i++) {
			Vector3 pos = kinkeis[i].transform.position;
			GameObject otherObj = i == 0 ? kinkeis[1] : kinkeis[0];
			if(pos.x <= -(float)width / 2) pos.x = otherObj.transform.position.x + width;
			pos.x -= Time.deltaTime * speed;
			kinkeis[i].transform.position = pos;
		}
	}
		
		
	///
	/// ユーザーからのキー入力を受け付けるメソッド
	///
	private void inputListen() {
		if(Input.GetKeyDown(KeyCode.UpArrow)) move(false);
		else if(Input.GetKeyDown(KeyCode.DownArrow)) move(true);
		//攻撃キー入力
		else if(Input.GetKeyDown(KeyCode.RightArrow)) attack();
	}

	private void attack() {
		Vector3 pos = characterInstance.transform.position;
		pos.y += 30f;
		GameObject burretInstance = Instantiate(burretPrefab, pos, Quaternion.identity);
		burretInstance.transform.SetParent(transform, true);

	}

	///
	/// キャラクターの移動を司るメソッド。
	///
	private void move(bool isDown) {
		Vector3 characterPos = characterInstance.transform.position;
		if(!isDown && currentPos -1 >= 0) {
			currentPos--;
			characterPos.y += posDiff;
		} else if(isDown && currentPos + 1 < positionRatios.Length) {
			currentPos++;
			characterPos.y -= posDiff;
		}	
		characterInstance.transform.position = characterPos;
	}

	private void updateSpeed() {

	}
}
