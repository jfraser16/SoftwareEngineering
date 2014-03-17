using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour
{
    public float buttonSize = 0.3f;

    /// <summary>
    /// Returns a Rect object with appropriate screen coordinates and dimaensions
    /// </summary>
    /// <param name="x">X screen coordinate value from 0 to 1</param>
    /// <param name="y">Y screen coordinate value from 0 to 1</param>
    /// <param name="content">The content of the GUI object (image, text, tooltip)</param>
    /// <returns></returns>
    Rect ScreenRect(int x, int y, GUIContent content)
    {
        float width;
        float height;
        width = Screen.width * buttonSize;
        height = Screen.height * buttonSize;
        return new Rect(Screen.width * x, Screen.height * y, width, height);
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
        switch (Application.loadedLevelName)
        {
            case "Logo":
                break;

            case "MainTitle":
                break;

            case "MainHub":
                break;

            case "MiniGameA":
                break;

            case "MiniGameB":
                break;

            case "MiniGameC":
                break;

            case "AwardsCeremony":
                break;
        }
    }
}
