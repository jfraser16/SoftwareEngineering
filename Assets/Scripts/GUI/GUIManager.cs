using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIManager : MonoBehaviour
{
    [System.Serializable]
    public class GUIitem
    {
        public bool isButton = false;
        public Font textFont;
        public Color textColor;
        public GUIContent content;
        public Vector2 position;
        public Vector2 size = new Vector2(0.3f, 0.3f);
        public TextAnchor textAlignment;
        public buttonResponse buttonResponse = buttonResponse.NOT_A_BUTTON;

        public void SetText(string newText) { content.text = newText; }
    }

    public GUIitem timer { get; private set; }
    public GUIitem quit { get; private set; }
    public GUIitem resume { get; private set; }
    public GUIitem pause { get; private set; }
    public GUIitem score { get; private set; }
    public GUIitem tutorial { get; private set; }
    public GUIitem winLose { get; private set; }
    public GUIitem nextscene { get; private set; }
    
    public List<GUIitem> otherGameContent;
    private GameManager GM;

    public virtual void Start()
    {
        // Get reference to GameManager if inside a game scene
        if (Application.loadedLevel != 0 && Application.loadedLevel != 1 && Application.loadedLevel != 2)
        {
            GM = GetComponent<GameManager>();
            BuildGUIitems();
            GUI.skin = Resources.Load("Default Skin") as GUISkin;
        }
    }

    protected void BuildGUIitems()
    {
        // build tutorial item
        tutorial = new GUIitem();
        tutorial.isButton = true;
        tutorial.buttonResponse = buttonResponse.CODED_MANUALLY;
        tutorial.position = new Vector2(0.5f, 0.5f);
        tutorial.size = new Vector2(0.9f, 0.9f);
        tutorial.content = new GUIContent();
        tutorial.content.image = GM.tutorialTexture;

        // build timer
        timer = new GUIitem();
        timer.position = new Vector2(0.5f, 0.0f);
        timer.size = new Vector2(0.3f, 0.05f);
        timer.content = new GUIContent();
        timer.content.text = "Timer";

        // build quit button
        quit = new GUIitem();
        quit.isButton = true;
        quit.buttonResponse = buttonResponse.RETURN_TO_MAIN;
        quit.position = new Vector2(0.5f, 0.6f);
        quit.size = new Vector2(0.3f, 0.05f);
        quit.content = new GUIContent();
        quit.content.text = "QUIT";

        // build resume button
        resume = new GUIitem();
        resume.isButton = true;
        resume.buttonResponse = buttonResponse.CODED_MANUALLY;
        resume.position = new Vector2(0.5f, 0.4f);
        resume.size = new Vector2(0.3f, 0.05f);
        resume.content = new GUIContent();
        resume.content.text = "RESUME";

        // build pause button
        pause = new GUIitem();
        pause.isButton = true;
        pause.buttonResponse = buttonResponse.CODED_MANUALLY;
        pause.position = new Vector2(0.0f, 1.0f);
        pause.size = new Vector2(0.15f, 0.1f);
        pause.content = new GUIContent();
        pause.content.image = Resources.Load("pause", typeof(Texture2D)) as Texture2D;

        // build score label
        score = new GUIitem();
        score.position = new Vector2(1.0f, 0.0f);
        score.size = new Vector2(0.3f, 0.05f);
        score.content = new GUIContent();
        score.content.text = "Score";

        // build win/lose label
        winLose = new GUIitem();
        winLose.position = new Vector2(0.5f, 0.4f);
        winLose.size = new Vector2(0.3f, 0.05f);
        winLose.content = new GUIContent();
        winLose.content.text = "Win/Lose";

        // build next scene (continue) label
        nextscene = new GUIitem();
        nextscene.isButton = true;
        nextscene.buttonResponse = GM.nextGame;
        nextscene.position = new Vector2(1.0f, 1.0f);
        nextscene.size = new Vector2(0.3f, 0.05f);
        nextscene.content = new GUIContent();
        nextscene.content.text = "Next Scene";
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

        if (item.size.x <= 0)
            width = 0;
        else if (item.size.x >= 1)
            width = Screen.width;
        else
            width = Screen.width * item.size.x;

        if (item.size.y <= 0)
            height = 0;
        else if (item.size.y >= 1)
            height = Screen.height;
        else
            height = Screen.height * item.size.y;

        x *= Screen.width;
        y *= Screen.height;

        if (x <= 0)
            left = 0;
        else if ((x - (width / 2)) >= Screen.width - width)
            left = Screen.width - width;
        else if (x > 0)
            left = x - (width / 2);

        if (y <= 0)
            top = 0;
        else if ((y - (height / 2)) >= Screen.height - height)
            top = Screen.height - height;
        else if (y > 0)
            top = y - (height / 2);

        return new Rect(left, top, width, height);
    }

    public virtual void DrawContinue()
    {
        if (GUI.Button(ScreenRect(nextscene.position.x, nextscene.position.y, nextscene), nextscene.content))
        {
            ButtonResponse.Response(nextscene.buttonResponse);
        }
    }

    public virtual void DrawScore()
    {
        GUI.Label(ScreenRect(score.position.x, score.position.y, score), score.content);
    }

    public virtual void DrawTimer()
    {
        GUI.Label(ScreenRect(timer.position.x, timer.position.y, timer), timer.content);
    }

    public virtual void DrawTutorial()
    {
        if (GUI.Button(ScreenRect(tutorial.position.x, tutorial.position.y, tutorial), tutorial.content))
        {
            GM.CurrentState = GameManager.stateTypes.RunGame;
        }
    }

    public virtual void DrawPause()
    {
        if (GUI.Button(this.ScreenRect(pause.position.x, pause.position.y, pause), pause.content))
        {
            GM.CurrentState = GameManager.stateTypes.Pause;
        }
    }

    public virtual void DrawQuit()
    {
        if (GUI.Button(this.ScreenRect(quit.position.x, quit.position.y, quit), quit.content))
        {
            ButtonResponse.Response(quit.buttonResponse);
        }
    }

    public virtual void DrawResume()
    {
        if (GUI.Button(this.ScreenRect(resume.position.x, resume.position.y, resume), resume.content))
        {
            GM.CurrentState = GameManager.stateTypes.RunGame;
        }
    }

    public virtual void DrawWinLose()
    {
        GUI.Label(ScreenRect(winLose.position.x, winLose.position.y, winLose), winLose.content);
    }

    public virtual void DrawOther()
    {
        foreach (GUIitem g in otherGameContent)
        {
            switch (g.isButton)
            {
                case true:
                    if (GUI.Button(this.ScreenRect(g.position.x, g.position.y, g), g.content))
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

    public virtual void OnGUI()
    {
        if (GM)
        {
            if (GM.CurrentState == GameManager.stateTypes.StartGame)
            {
                DrawTutorial();
            }

            else if (GM.CurrentState == GameManager.stateTypes.RunGame)
            {
                DrawScore();
                DrawTimer();
                DrawPause();
                DrawContinue();
            }

            else if (GM.CurrentState == GameManager.stateTypes.Pause)
            {
                DrawScore();
                DrawTimer();
                DrawQuit();
                DrawResume();
            }

            else if (GM.CurrentState == GameManager.stateTypes.EndGame)
            {
                DrawScore();
                DrawTimer();
                DrawContinue();
                DrawWinLose();
            }
        }

        else
            DrawOther();
    }
}
