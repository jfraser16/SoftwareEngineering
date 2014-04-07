﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GUIManager))]
public class GameManager : MonoBehaviour {

	public GUIManager myGui;
    public GameTimer myGameTimer = new GameTimer();

	public enum stateTypes {StartGame, RunGame, EndGame,Pause};

	public stateTypes CurrentState = stateTypes.StartGame;

	public float MaxGameTime;


	public virtual void Awake()
	{
		//Require Components
		myGui = gameObject.GetComponent<GUIManager>() as GUIManager;

	}
	public virtual void Start()
	{
		//Secondary Require Components
		myGui = gameObject.GetComponent<GUIManager>() as GUIManager;
		myGameTimer.setMaxTime(MaxGameTime);
	}

	public virtual void RunStartGame()
	{
		//I suggest we extend Class Function through inheritance

	}

	public virtual void RunGame()
	{
		//I suggest we extend Class Function through inheritance
		myGameTimer.Update(Time.deltaTime);
		myGui.timer.content.text = ("Time: " + (int)myGameTimer.currentTime + " / " + (int)myGameTimer.maxTime);
		if (myGameTimer.currentTime >= myGameTimer.maxTime)
		{
			CurrentState = stateTypes.EndGame;
		}

	}

	public virtual void RunEndGame()
	{
		//I suggest we extend Class Function through inheritance
		myGameTimer.stop();
	}
	public virtual void RunPause()
	{
		myGameTimer.stop();
		//I suggest we extend Class Function through inheritance
	}

    public virtual void StartGame()
    {
        CurrentState = stateTypes.RunGame; 
    }

	public virtual void Update()
	{



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

	public virtual void QuitGame() 
	{
		Application.Quit();
	}

	public virtual void RestartGame()
	{
		CurrentState = stateTypes.StartGame;
		myGameTimer.reset();
	}

}
