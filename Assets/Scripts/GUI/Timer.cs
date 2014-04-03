using UnityEngine;
using System.Collections;

public class Timer{
	public float maxTime { get; private set; }
	public float startTime { get; private set; }
	public float currentTime { get; private set; }

	public Timer()
	{
		maxTime = 0;
		startTime = 0;
		currentTime = 0;
	}
	public void setMaxTime(int _m) { maxTime = _m; }
	public void setStartTime(int _s) { startTime = _s; }
	public void setCurrentTime(int _m) { currentTime = _m; }

	public void start () {} 
	public void stop () {}
	public void reset () {}
}
