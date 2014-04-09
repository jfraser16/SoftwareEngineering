using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GUIManager))]
public class SheepGameManager : GameManager {
	public SheepSpawner mySpawner;

	public float timeBetweenSpawns = 1.0f;
	public float currentTimeSpawn = 0;
	public float lastTimeSpawn =0;


	public int TotalSheepCreated = 0;

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
		//currentTimeSpawn = myGameTimer.currentTime;
		if ((currentTimeSpawn - lastTimeSpawn) >= timeBetweenSpawns) 
		{
			lastTimeSpawn = currentTimeSpawn;
			mySpawner.SpawnSheep();
			TotalSheepCreated++;
		}


	}
	
	new public void RunEndGame()
	{
		base.RunEndGame();

	}
	new public void RunPause()
	{

	//	myGameTimer.stop();

	}


	// Update is called once per frame
	void Update () {
		//State Machine Switch
		if (CurrentState == stateTypes.StartGame)
		{
			RunStartGame();
		}
		else if(CurrentState == stateTypes.RunGame)
		{
			RunGame();
		}
		else if(CurrentState == stateTypes.EndGame)
		{
			RunEndGame();
		}
		else if(CurrentState == stateTypes.Pause)
		{
			RunPause();
		}
	}
}
