using UnityEngine;
using System.Collections;

public class Timer{
	public float maxTime { get; private set; }
	public float startTime { get; private set; }
	public float currentTime { get; private set; }

	public void setMaxTime(int _m) { maxTime = _m; }
	public void setStartTime() { startTime = Time.time; }
	public void setCurrentTime() { currentTime = Time.time; }

	// To use this, you need to set maxtime in seconds and starttime just call, then startGame in udpate; 

	public bool startGame () 
	{
		setCurrentTime ();
		Debug.Log (currentTime - startTime);
		//Debug.Log (currentTime - startTime);
		if (currentTime - startTime >= maxTime)
			return true;
		else
			return false;
	} 
	public void stop () 
	{
		

	}
	public void reset () 
	{


	}
}
