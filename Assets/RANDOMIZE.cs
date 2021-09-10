using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RANDOMIZE : MonoBehaviour {
	
	private int numberofpipes;
	private int numberofrocks;
	private int numberofback;
	private float destancebetw;
	private float destancebetween;
	private float destance;
	int i;
	int count;
	public float pipemax=0.3f;
	public float pipemin=2.5f;
	public Rigidbody2D rigid;
	public GameObject gb;
	public GameObject gb1;
	public GameObject gb2;
	public GameObject gb3;
	public GameObject gb4;
	public GameObject gb5;
	public GameObject rigidb;



	public void Start(){
		GameObject[] backgrounds = GameObject.FindGameObjectsWithTag ("BACKGROUND");
		GameObject[] pipes = GameObject.FindGameObjectsWithTag ("PIPE");
		GameObject[] rocks = GameObject.FindGameObjectsWithTag ("ROCK");
		numberofpipes = pipes.Length;
		numberofrocks = rocks.Length;
		numberofback=  backgrounds.Length;
		foreach (GameObject pipe in pipes) {
			Vector3 pos = pipe.transform.position;
			pos.x = Random.Range (pipemin, pipemax);
			pipe.transform.position = pos;
			this.destancebetw = Mathf.Abs ((gb1.transform.position.y - gb.transform.position.y) - 2.0f);
		}
		foreach (GameObject rock in rocks) {
			Vector3 pos = rock.transform.position;
			rock.transform.position = pos;
			this.destancebetween = Mathf.Abs(gb2.transform.position.y - gb3.transform.position.y);
		}
		foreach (GameObject background in backgrounds) {
			Vector3 pos = background.transform.position;
			background.transform.position = pos;
			this.destance = Mathf.Abs(gb4.transform.position.y - gb5.transform.position.y);
		}
		rigidb.GetComponent<Rigidbody2D> ().velocity = rigidb.GetComponent<Rigidbody2D> ().velocity + new Vector2 (0, -2);

	}

	public void OnTriggerEnter2D(Collider2D collider){
		if (collider.CompareTag ("PIPE")) {
			count++;
			var pipe = collider.gameObject;
			var pipeposition = pipe.transform.position;
			pipeposition.y = this.numberofpipes * this.destancebetw;
			pipe.transform.position = pipeposition;
			if (count > 48 && count < 98) {
				rigidb.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -8.5f, 0);

			}
			if(count>100) {
				rigidb.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -11, 0);
				pipeposition.y = this.numberofpipes * (this.destancebetw-5.0f);
				pipe.transform.position = pipeposition;

			}

		}
		if (collider.CompareTag ("ROCK")) {
			var rock = collider.gameObject;
			var rockposition = rock.transform.position;
			rockposition.y = (this.numberofrocks-1)* this.destancebetween;
			rock.transform.position = rockposition;

		}
		if (collider.CompareTag ("BACKGROUND")) {
			var back = collider.gameObject;
			var backposition = back.transform.position;
			backposition.y = (this.numberofback-1) * this.destance;
			back.transform.position = backposition;
		}
	}

		
}

