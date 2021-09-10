using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class move : MonoBehaviour
{
	public Canvas canvasAd;
	public Canvas canvasexit;
	public GameObject gb;
	public SpriteRenderer spriterende;
	public Sprite[] sprite;
	public RuntimeAnimatorController[] animcontr;
	public Animator anim;
	public Text scoreText;
	public GameObject gb1;
	public AudioClip win, gameover,loop;
	public AudioSource audiosrc1;
	private AudioSource audiosrc;
	private bool scenebool = false;
	private int count=0;
	private int br;
	private int countad;
	private int min;
	private int max;
	private int ran1;
	private float time = 0.9f;
	private string gameid="1593080";

	private IEnumerator co;

	public void Start()
	{ if (Advertisement.isSupported && !Advertisement.isInitialized) {
			Advertisement.Initialize (gameid);
		}
		audiosrc = GetComponent<AudioSource> ();
		canvasAd.enabled=false;
		Time.timeScale = 0.0f;
		spriterende.enabled = false;
		min = 50;
		max = 56;
		anim.enabled = false;
		int i;
		int charecter = PlayerPrefs.GetInt ("Character",0);
		int nameanim = PlayerPrefs.GetInt ("animator", 0);
		for (i = 0; i < sprite.Length; i++) {
			if (charecter==i) {
				this.GetComponent<SpriteRenderer> ().sprite = sprite [i];
			}
			if (nameanim==i) {
				this.GetComponent<Animator> ().runtimeAnimatorController = animcontr [i];
			}

		}
	}
	void Update ()

	{  
		

		if ((canvasAd.enabled == true)||(canvasexit.enabled==true))  {
			this.transform.position = new Vector3 (0, -2.3f, 0);

		} else {
			movebat ();
		
		}
		if (canvasexit.enabled == true) {
			audiosrc1.Pause ();
		}

	}
	public void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag ("pipecol") || (coll.gameObject.CompareTag ("ROCKS"))) {
			audiosrc1.Pause ();
			audiosrc.PlayOneShot (gameover);
			br++;
			if (br == 1) {
				Time.timeScale = 0;
				spriterende.enabled = false;
				co = MyCoroutine ();
				StartCoroutine (co);

			}
			if (br > 1) {
				gb1.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);
				this.GetComponent<Animator> ().enabled = false;
				audiosrc1.Pause ();
				canvasAd.enabled = false;
				Invoke ("InvokeScene",0.7f);
				br = 0;

			}
		}
	}


	public void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.CompareTag ("PIPE")) {
			count++;
			scoreText.text = count.ToString ();
			audiosrc.PlayOneShot (win);
			if (count == min ) {
				ran1 = Random.Range (max, min);
		}

			if (count==ran1 && count>49&&count<98){
					StartCoroutine (MyBlack ());
					min += 12;
					max += 12;
				} else {
					spriterende.enabled = false;
				}
			}



			if (count > PlayerPrefs.GetInt ("Best Score", 0)) {

				PlayerPrefs.SetInt ("Best Score", count);
			}
		}

	public void FixedUpdate()
	{
		PlayerPrefs.SetInt ("Score", count);

	} 

		
	public void movebat()
	{
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		bool overSprite = this.GetComponent<SpriteRenderer> ().bounds.Contains (mousePosition);
		if (overSprite) {
			if (Input.GetButton ("Fire1")) {
				this.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 
					-2.5f,
					0.0f);
				Destroy (gb);
				Time.timeScale = 1.0f;
			}
		}

	}
	public void InvokeScene()
	{	Time.timeScale = 1.0f;
		SceneManager.LoadScene ("gameover");	

	}
	public void InvokeAd(){
		scenebool = true;
		Invoke ("invokeCanvas", 2f);
	
	}
	public void invokeCanvas(){
		canvasAd.enabled = false;
	}
	public void InvokeStart(){
		Time.timeScale = 1.0f;
	}
	public IEnumerator MyCoroutine()
	{ 
		scenebool = false;
		canvasAd.enabled = true;
		anim.enabled = true;
		yield return StartCoroutine (CoroutineUtil.WaitForRealSeconds (5));
		audiosrc1.Play();
		anim.enabled = false;

		canvasAd.enabled = false;
		if (canvasAd.enabled == false && scenebool == false) {
			audiosrc.Pause ();
			Time.timeScale = 1.0f;
			InvokeScene ();


		}
	}
	public IEnumerator MyBlack(){
		spriterende.enabled=true;
		yield return StartCoroutine (CoroutineUtil.WaitForRealSeconds (time));
		spriterende.enabled = false;

		
	}
	public 	void ShowRewardedVideo ()
	{
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show("rewardedVideo", options);
	}

	void HandleShowResult (ShowResult result)
	{
		if(result == ShowResult.Finished) {
			canvasAd.enabled = false;
		}else if(result == ShowResult.Skipped) {
			Time.timeScale = 0f;

		}else if(result == ShowResult.Failed) {
			InvokeScene ();
		}
	}
}

public static class CoroutineUtil
{
	public static IEnumerator WaitForRealSeconds(float time)
	{
		float start = Time.realtimeSinceStartup;
		while (Time.realtimeSinceStartup < start + time)
		{
			yield return null;
		}
	}
	}


		


