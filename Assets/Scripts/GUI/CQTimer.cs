using UnityEngine;
using System.Collections;

public static class CQTimer{
	public static bool active = false;

	public static float maxTime { get; private set; }
	public static float startTime { get; private set; }
	public static float currentTime { get; private set; }
	public static float remainTime { get { return maxTime - currentTime; } private set{} }
	private static float oldTime = 0;
	private static float diffTime = 0;

	public static void setMaxTime(int _m) { maxTime = _m; }
	public static void setStartTime() { startTime = Time.time; }
	public static void setCurrentTime() { currentTime = Time.time; }

	public static bool updateTimer () 
	{
		if(active == true)
		{
			currentTime = Time.time - diffTime;
			if (currentTime - startTime >= maxTime)
				return true;
			else
				return false;
		}
		else
		{
			return false;
		}
	} 
	public static void toggle () 
	{
		if(active == false)
		{
			active = true;
			currentTime = Time.time;
			diffTime = currentTime - oldTime;
			Debug.Log ("Old Time is "+oldTime);
			Debug.Log ("Current Time is "+currentTime);
			Debug.Log ("Diff Time is "+diffTime);
			//Debug.Log (diffTime);
		}
		else 
		{
			oldTime = currentTime;
			active = false;
		}
	}
	public static void reset () 
	{


	}
}
