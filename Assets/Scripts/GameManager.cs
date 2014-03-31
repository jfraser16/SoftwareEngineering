using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GUIManager))]
[RequireComponent (typeof (Timer))]
public class GameManager : MonoBehaviour {

	public string instructions;

	public GUIManager myGui;
	public Timer GameTimer;

	public enum stateTypes {StartGame, RunGame, EndGame,Pause};

	public stateTypes CurrentState = stateTypes.StartGame;
	


	public void Awake()
	{
		//Require Components
		myGui = gameObject.GetComponent<GUIManager>() as GUIManager;
		GameTimer = gameObject.GetComponent<Timer>() as Timer;
	}
	public void Start()
	{
		//Secondary Require Components
		myGui = gameObject.GetComponent<GUIManager>() as GUIManager;
		GameTimer = gameObject.GetComponent<Timer>() as Timer;
	}

	public void RunStartGame()
	{
		//I suggest we extend Class Function through inheritance
	}

	public void RunGame()
	{
		//I suggest we extend Class Function through inheritance
	}

	public void RunEndGame()
	{
		//I suggest we extend Class Function through inheritance
	}
	public void RunPause()
	{
		//I suggest we extend Class Function through inheritance
	}

	public void Update()
	{
		//Try to extend states and not the state machine
		//Extend base class for state machine behavior changes
		if (Input.GetButtonDown("start") && CurrentState == stateTypes.StartGame)
		{
			CurrentState = stateTypes.RunGame;
		}

		if (Input.GetButtonDown("Quit") && CurrentState == stateTypes.StartGame)
		{
			QuitGame();
		}

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

	void QuitGame() 
	{
		Application.Quit();
	}

	void RestartGame()
	{

	}

}
