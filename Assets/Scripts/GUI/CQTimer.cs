using UnityEngine;
using System.Collections;

public static class CQTimer{
	public static float maxTime { get; private set; }
	public static float startTime { get; private set; }
	public static float currentTime { get; private set; }
	public static float remainTime { get { return maxTime - currentTime; } private set{} }

	public static void setMaxTime(int _m) { maxTime = _m; }
	public static void setStartTime() { startTime = Time.time; }
	public static void setCurrentTime() { currentTime = Time.time; }

	public static bool updateTimer () 
	{
		setCurrentTime ();
		if (currentTime - startTime >= maxTime)
			return true;
		else
			return false;
	} 
	public static void stop () 
	{


	}
	public static void reset () 
	{


	}
}
