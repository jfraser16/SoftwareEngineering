using UnityEngine;
using System.Collections;

public class SheepBehavior : MonoBehaviour {


	public float forwardspeed = 5.0f;
	public bool isJumping = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//							left translation 
		if (isJumping == false) 
		{
			rigidbody2D.AddForce (((Vector2.right * (-1)) * forwardspeed * Time.deltaTime));
		}
	}

	public void Jump(float power)
	{
		Debug.Log ("received jump");
		if (isJumping == false) 
		{
			isJumping = true;
			rigidbody2D.AddForce((Vector2.up * power));

		}
	}

	public void HitGround(float dummyfloat)
	{
		if (isJumping == true) 
		{
			isJumping = false;
		}
	}
}
