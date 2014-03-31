using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GUIitem
{
	public bool isButton;
	public GUIContent content;
	public Vector2 position;
	public int buttonResponse;
	public float buttonSize = 0.3f;
}


public class GUIManager : MonoBehaviour
{
	public Font myFont;

	public List<GUIitem> content;

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

        return new Rect(left, (Screen.height * y)-(height/2), width, height);
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
		foreach(GUIitem g in content)
		{
			switch(g.isButton)
			{
			case true:
				if(GUI.Button(this.ScreenRect(g.position.x, g.position.y, g), g.content))
				{
					// do something with g.buttonResponse
				}
				break;

			case false:
				GUI.Label(ScreenRect(g.position.x, g.position.y, g), g.content);
				break;
			}
		}
//
//        switch (Application.loadedLevelName)
//        {
//            case "Logo":
//                break;
//
//            case "MainTitle":
//                break;
//
//            case "MainHub":
//                break;
//
//            case "MiniGameA":
//                break;
//
//            case "MiniGameB":
//                break;
//
//            case "MiniGameC":
//                break;
//
//            case "AwardsCeremony":
//                break;
//        }
    }
}
