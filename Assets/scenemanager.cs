using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class scenemanager : MonoBehaviour {
	public Text score;
	public Text best;
	public Text star;
	static int countad=0;



	void Start ()
	{
		int count;
		int count1;
		count = PlayerPrefs.GetInt ("Score", 0);
		count1 = PlayerPrefs.GetInt ("star", 0);
		score.text = PlayerPrefs.GetInt ("Score", 0).ToString ();
		PlayerPrefs.GetInt ("Best Score", 0);
		best.text = PlayerPrefs.GetInt ("Best Score", 0).ToString ();
		count1 = count + count1;
		PlayerPrefs.SetInt ("star", count1);
		PlayerPrefs.GetInt ("star", 0);
		star.text = PlayerPrefs.GetInt ("star", 0).ToString ();
		countad++;
		if (countad == 3) {
			Advertisement.Show ("video");
			countad = 0;
			PlayerPrefs.SetInt ("countad", countad);
		}

	}
}