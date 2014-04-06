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

            case buttonResponse.LOAD_MINIGAME_A:
                GoToMiniGameA();
                break;
            
            case buttonResponse.LOAD_MINIGAME_B:
                GoToMiniGameB();
                break;

            case buttonResponse.LOAD_MINIGAME_C:
                GoToMiniGameC();
                break;

            case buttonResponse.LOAD_AWARDS_SCENE:
                GoToAwardsScene();
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

    static void GoToMiniGameA()
    {
        Application.LoadLevel("MiniGameA");
    }

    static void GoToMiniGameB()
    {
        Application.LoadLevel("MiniGameB");        
    }

    static void GoToMiniGameC()
    {
        Application.LoadLevel("MiniGameC");
    }

    static void GoToAwardsScene()
    {
        Application.LoadLevel("AwardsCeremony");
    }

    static void QuitApp()
    {
        Application.Quit();
    }

    static void ReturnToMain()
    {
        Application.LoadLevel("MainHub"); 
    }
}
