using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
	Material myMaterial;

	//ボールが見える可能性のあるZ軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバーを表示するテキスト
	private GameObject gameoverText;

	//pointを表示するテキスト
	private GameObject point;

	//ポイントの格納場所
	public int tokutenn = 0;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find ("GameOverText");
		//シーン中のPointオブジェクトを取得
		this.point = GameObject.Find ("Point");
		this.point.GetComponent<Text> ().text = tokutenn.ToString ();
	}

	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバーを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "SmallStarTag") {
			tokutenn += 10;
			this.point.GetComponent<Text>().text = tokutenn.ToString();
		} else if (other.gameObject.tag == "LargeStarTag") {
			tokutenn += 20;
			this.point.GetComponent<Text>().text = tokutenn.ToString();
		} else if (other.gameObject.tag == "SmallCloudTag") {
			tokutenn += 30;
			this.point.GetComponent<Text>().text = tokutenn.ToString();
		} else if (other.gameObject.tag == "LargeCloudTag") {
			tokutenn += 40;
			this.point.GetComponent<Text>().text = tokutenn.ToString();
		}
	}

}