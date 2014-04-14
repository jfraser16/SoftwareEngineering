using UnityEngine;
using System.Collections;

public class TriggerJump : MonoBehaviour {
	public float jumppower = 500.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {

		other.SendMessage ("Jump", jumppower);
	}


}
