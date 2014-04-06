using UnityEngine;
using System.Collections;

public static class Scoring{
	//public static int score { get; private set; }
	
    //public static int gameID { get; private set; } 

    //public Scoring()
    //{
    //    score = 0;
    //    gameID = 0;
    //}

    public static void setScore(string game, int _s) { PlayerPrefs.SetInt(game, _s); }
    public static int getScore(string game) { return PlayerPrefs.GetInt(game); }
	//public static void setID(int _i) { gameID = _i; }
}
