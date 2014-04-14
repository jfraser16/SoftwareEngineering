using UnityEngine;
using System.Collections;

public class ContactGround : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{

		coll.gameObject.SendMessage("HitGround", 0.0f);
	}
}