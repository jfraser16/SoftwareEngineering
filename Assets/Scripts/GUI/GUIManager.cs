using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIManager : MonoBehaviour
{
    [System.Serializable]
    public class GUIitem
    {
        public bool isButton;
        public GUIContent content;
        public Vector2 position;
        public buttonResponse buttonResponse;
        public float buttonSize = 0.3f;
    }

	public Font myFont;

    public GUIitem timer;
    public GUIitem score;
    public GUIitem pause;
    public GUIitem quit;
    public GUIitem resume;
    public GUIitem tutorial;
    public GUIitem nextscene;
    public List<GUIitem> otherGameContent;
    public GameManager GM;

    public void Start()
    {
        // Get reference to GameManager if inside a game scene
        if(Application.loadedLevel != 0 && Application.loadedLevel != 1 && Application.loadedLevel != 2)
            GM = Camera.main.GetComponent<GameManager>();
    }

    /// <summary>
    /// Returns a Rect object with appropriate screen coordinates and dimaensions
    /// </summary>
    /// <param name="x">X screen coordinate value from 0 to 1</param>
    /// <param name="y">Y screen coordinate value from 0 to 1</param>
    /// <param name="content">The content of the GUI object (image, text, tooltip)</param>
    /// <returns></returns>
    public Rect ScreenRect(float x, float y, GUIitem item)
    {
        float width = 0;
        float height = 0;
		float top = 0;
		float left = 0;

		width = Screen.width * item.buttonSize;

        if (item.buttonSize == 1)
            height = Screen.height * item.buttonSize;
        else
            height = Screen.height * (item.buttonSize / 3);
		x *= Screen.width;
		y *= Screen.height;

		if(x <= 0)
			left = 0;
		else if (x >= Screen.width - width)
			left = Screen.width - width;
		else if (x > 0)
			left = x - (width/2);

        if (y <= 0)
            top = 0;
        else if (y >= Screen.height - height)
            top = Screen.height - height;
        else if (y > 0)
            top = y - (height/2);
        
        return new Rect(left, top, width, height);
    }

    public void DrawContinue()
    {
        if (GUI.Button(ScreenRect(nextscene.position.x, nextscene.position.y, nextscene), nextscene.content))
        {
            ButtonResponse.Response(nextscene.buttonResponse);
        } 
    }

    public void DrawScore()
    {
        GUI.Label(ScreenRect(score.position.x, score.position.y, score), score.content);
    }
    
    public void DrawTimer()
    {
        GUI.Label(ScreenRect(timer.position.x, timer.position.y, timer), timer.content);
    }

    public void DrawTutorial()
    {
        // renderer Tutorial
        if (GUI.Button(ScreenRect(tutorial.position.x, tutorial.position.y, tutorial), tutorial.content))
        {
            GM.CurrentState = GameManager.stateTypes.RunGame;
        }
    }

    public void DrawPause()
    {
        if (GUI.Button(this.ScreenRect(pause.position.x, pause.position.y, pause), pause.content))
        {
            GM.CurrentState = GameManager.stateTypes.Pause;
        }
    }

    public void DrawQuit()
    {
        if (GUI.Button(this.ScreenRect(quit.position.x, quit.position.y, quit), quit.content))
        {
            ButtonResponse.Response(quit.buttonResponse);
        }
    }

    public void DrawResume()
    {
        if (GUI.Button(this.ScreenRect(resume.position.x, resume.position.y, resume), resume.content))
        {
            GM.CurrentState = GameManager.stateTypes.RunGame;
        }
    }

    public void OnGUI()
    {
        if (GM)
        {
            if (GM.CurrentState == GameManager.stateTypes.StartGame)
            {
                DrawTutorial();
            }

            else if (GM.CurrentState == GameManager.stateTypes.RunGame)
            {
                // draw score, timer, pause
                DrawScore();
                DrawTimer();
                DrawPause();
                DrawContinue();
            }

            else if (GM.CurrentState == GameManager.stateTypes.Pause)
            {
                // draw score, timer
                DrawScore();
                DrawTimer();

                // draw quit, resume
                DrawQuit();
                DrawResume();
            }

            else if (GM.CurrentState == GameManager.stateTypes.EndGame)
            {
                // draw score, timer, continue
                DrawScore();
                DrawTimer();
                DrawContinue();
            }
        }

		foreach(GUIitem g in otherGameContent)
		{
			switch(g.isButton)
			{
			case true:
				if(GUI.Button(this.ScreenRect(g.position.x, g.position.y, g), g.content))
				{
                    ButtonResponse.Response(g.buttonResponse);
				}
				break;

			case false:
				GUI.Label(ScreenRect(g.position.x, g.position.y, g), g.content);
				break;
			}
		}
    }
}
