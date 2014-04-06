using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GUIManager))]
public class GameManager : MonoBehaviour {

	public string instructions;

	public GUIManager myGui;
    public GameTimer myGameTimer = new GameTimer();

	public enum stateTypes {StartGame, RunGame, EndGame,Pause};

	public stateTypes CurrentState = stateTypes.StartGame;

	public float MaxGameTime;


	public void Awake()
	{
		//Require Components
		myGui = gameObject.GetComponent<GUIManager>() as GUIManager;

	}
	public void Start()
	{
		//Secondary Require Components
		myGui = gameObject.GetComponent<GUIManager>() as GUIManager;
		myGameTimer.setMaxTime(MaxGameTime);
	}

	public void RunStartGame()
	{
		//I suggest we extend Class Function through inheritance

	}

	public void RunGame()
	{
		//I suggest we extend Class Function through inheritance
		myGameTimer.Update(Time.deltaTime);
	}

	public void RunEndGame()
	{
		//I suggest we extend Class Function through inheritance
		myGameTimer.stop();
	}
	public void RunPause()
	{
		myGameTimer.stop();
		//I suggest we extend Class Function through inheritance
	}

	public void Update()
	{
		myGameTimer.Update(Time.deltaTime);

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
		CurrentState = stateTypes.StartGame;
		myGameTimer.reset();
	}

}
