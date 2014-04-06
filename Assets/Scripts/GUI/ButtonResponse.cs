using UnityEngine;
using System.Collections;

public class ButtonResponse : MonoBehaviour
{
    /// <summary>
    /// If you want to add a button Response, first you must
    /// add a new Enum ID (open Enums.cs).
    /// Then add your case below and write the static function at the end of this script.
    /// </summary>
    /// <param name="ID"></param>
    public static void Response(buttonResponse ID)
    {
        switch (ID)
        {
            case buttonResponse.PAUSE:
                Pause();
                break;

            case buttonResponse.START:
                Start();
                break;
            
            case buttonResponse.QUITAPP:
                QuitApp();
                break;
            
            case buttonResponse.RETURN_TO_MAIN:
                ReturnToMain();
                break;
            
            default:
                break;
        }
    }

    static void Pause()
    {
 
    }

    static void Start()
    {
        Application.LoadLevel("MainHub");
    }

    static void QuitApp()
    {
 
    }

    static void ReturnToMain()
    {
 
    }
}
