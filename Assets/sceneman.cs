using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneman : MonoBehaviour {
	public string Androidrate="market://details?id=com.VKentartainment";
	public Canvas canvasexit;
	void Start(){
		canvasexit.enabled = false;
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			canvasexit.enabled = true;
			Time.timeScale = 0;


		}
	}
		
	public void sceneLoad(string scene)
	{
		SceneManager.LoadScene (scene);

		Time.timeScale = 1.0f;


	}
	public void ButtonRate(){
		Application.OpenURL (Androidrate);
		
	}
	public void AudioSource(AudioSource audio){
		audio.Play ();
	}


	public void pausescene(Canvas canvas)
	{
		Invoke ("pausescene", 3f);
		canvas.enabled = false;
		Time.timeScale = 1.0f;


	}
	public void ExitGame(){
		Application.Quit ();
	}

}