using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buy : MonoBehaviour {
	public Canvas canvasbuy;
	public RuntimeAnimatorController[] contr;
	public Sprite[] sprite;
	public GameObject[] but;
	private int i;
	void Start () {
		canvasbuy.enabled = false;
		for (i = 0; i < but.Length; i++) {
			if (but [0].ToString () == PlayerPrefs.GetString ("gb", "button")) {
				PlayerPrefs.SetString ("buy", but [0].ToString ());
			}
			if (but [1].ToString () == PlayerPrefs.GetString ("gb", "button")) {
				PlayerPrefs.SetString ("buy1", but [1].ToString ());
			}
			if (but [2].ToString () == PlayerPrefs.GetString ("gb", "button")) {
				PlayerPrefs.SetString ("buy2", but [2].ToString ());
			}
			if (but [3].ToString () == PlayerPrefs.GetString ("gb", "button")) {
				PlayerPrefs.SetString ("buy3", but [3].ToString ());
			}
			if (but [4].ToString () == PlayerPrefs.GetString ("gb", "button")) {
				PlayerPrefs.SetString ("buy4", but [4].ToString ());
			}

		}
		for (i = 0; i < but.Length; i++) {
			if (PlayerPrefs.GetString ("buy", "buy") == but [0].ToString ()){
				Destroy (but [0]);
			}
			if (PlayerPrefs.GetString ("buy1", "buy") == but [1].ToString ()){
				Destroy (but [1]);
			}
			if (PlayerPrefs.GetString ("buy2", "buy") == but [2].ToString ()){
				Destroy (but [2]);
			}
			if (PlayerPrefs.GetString ("buy3", "buy") == but [3].ToString ()){
				Destroy (but [3]);
			}
			if (PlayerPrefs.GetString ("buy4", "buy") == but [4].ToString ()){
				Destroy (but [4]);
			}

		}}


	public void SpriteChange(int spriteNUM){
		int i;
		for (i = 0; i < sprite.Length; i++) {
			if (spriteNUM == i) {
				PlayerPrefs.SetInt ("Character", spriteNUM);
				PlayerPrefs.SetInt("animator", spriteNUM);
			}
		}
	}

	public void Buy(GameObject gb){
		int a;
		a = PlayerPrefs.GetInt ("star", 0);
		if (a < 200) {
			Debug.Log ("play more");
		} else {
			PlayerPrefs.SetString ("button1", gb.ToString ());
			a -= 200;
			PlayerPrefs.SetInt ("star", a);
			PlayerPrefs.SetString ("gb", gb.ToString ());
			Destroy (gb);
		}
	}

	public void CanvasOpen(){
		canvasbuy.enabled = true;
	}
	public void CanvasExit(){
		canvasbuy.enabled = false;
	}
}
