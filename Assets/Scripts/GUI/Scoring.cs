using UnityEngine;
using System.Collections;

public class Scoring{
	public int score { get; private set; }
	public int gameID { get; private set; } 

	public Scoring()
	{
		score = 0;
		gameID = 0;
	}

	public void setScore(int _s) { score = _s; }
	public void setID(int _i) { gameID = _i; }
}
