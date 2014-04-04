using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour
{
    public int x { get; private set; }
    public int y { get; private set; }
    public void SetPosition(int i, int j) { x = i; y = j; }

    public cardColour face { get; private set; }
    public void setFace(cardColour _f) { face = _f; SetColor(); }
    private void SetColor() { renderer.material.color = getColor(face); }

    public void print() { Debug.Log(face); }

    public Color getColor(cardColour _a)
    {
        if (_a == cardColour.RED) { return Color.red; }
        else if (_a == cardColour.GREEN) { return Color.green; }
        else if (_a == cardColour.BLUE) { return Color.blue; }
        else if (_a == cardColour.CYAN) { return Color.cyan; }
        else if (_a == cardColour.YELLOW) { return Color.yellow; }
        else if (_a == cardColour.MAGENTA) { return Color.magenta; }
        else if (_a == cardColour.WHITE) { return Color.white; }
        else if (_a == cardColour.BLACK) { return Color.black; }
        return Color.clear;
    }

    void OnMouseUp()
    {
        Debug.Log(x + " " + y + " " + face);
        SetColor();
    }
}