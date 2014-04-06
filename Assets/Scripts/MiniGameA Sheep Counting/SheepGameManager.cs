using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GUIManager))]
public class SheepGameManager : GameManager {

	void Awake(){
		base.Awake();
	}

	// Use this for initialization
	void Start () {
		base.Start ();
	}
	new public void RunStartGame()
	{
		base.RunStartGame ();

	}
	
	new public void RunGame()
	{
		base.RunGame ();

	}
	
	new public void RunEndGame()
	{
		base.RunEndGame();

	}
	new public void RunPause()
	{

		myGameTimer.stop();

	}


	// Update is called once per frame
	void Update () {
		base.Update();
	}
}
