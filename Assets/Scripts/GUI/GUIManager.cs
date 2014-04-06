using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIManager : MonoBehaviour
{
	public Font myFont;

    public GUIitem timer;
    public GUIitem score;
    public GUIitem tutorial;
    public List<GUIitem> otherGameContent;

    public void Start()
    {
        
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
        height = Screen.height * item.buttonSize;
		x *= Screen.width;
		y *= Screen.height;

		if(x <= 0)
			left = 0;
		else if (x >= Screen.width - width)
			left = Screen.width - width;
		else if (x > 0)
			left = x;

        if (y <= 0)
            top = 0;
        else if (y >= Screen.height - height)
            top = Screen.height - height;
        else if (y > 0)
            top = y;
        
        return new Rect(left, top, width, height);
    }

    public GUIContent DrawScore()
    {
        GUIContent newContent = new GUIContent();
        //newContent.text = scoring.getScore();
        return newContent;
    }
    
    public GUIContent DrawHighScore()
    {
        GUIContent newContent = new GUIContent();
        //newContent.text = scoring.getHighScore();
        return newContent;
    }

    public void DrawTimer()
    {
        
    }

    public void DrawTimeBar()
    {

    }

    public void DrawPauseQuit()
    {

    }

    public static void DrawLogo()
    {

    }

    public void OnGUI()
    {
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
