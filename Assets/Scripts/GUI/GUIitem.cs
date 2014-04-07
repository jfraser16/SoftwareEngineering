using UnityEngine;
using System.Collections;

[System.Serializable]
public class GUIitem : MonoBehaviour 
{
    public bool isButton;
    public GUIContent content;
    public Vector2 position;
    public buttonResponse buttonResponse;
    public float buttonSize = 0.3f;
}
