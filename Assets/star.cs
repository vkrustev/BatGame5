using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour {
	private int count;
	public SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerEnter2D(Collider2D collider){
		if(collider.CompareTag("BAT")){
			sprite.enabled=false;

		}
		if(collider.CompareTag("LOOPER")){
				sprite.enabled=true;
			}
	}
		
}
