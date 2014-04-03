using UnityEngine;
using System.Collections;

public enum cardColour
{	
	RED, 
	GREEN, 
	BLUE, 
	CYAN, 
	YELLOW, 
	MAGENTA, 
	WHITE, 
	BLACK, 
	MAX
}

public class Card : MonoBehaviour{
	public int face;
	//public Position position;
	public int x;
	public int y;

	public Card card;

	public Card(int _a, int _b)
	{
		face = 1000;
		x = _a;
		y = _b;
		//position = new Position (_a, _b);
	}

	public Color getColor(cardColour _a)
	{
		if(_a == cardColour.RED) { return Color.red; }
		else if(_a == cardColour.GREEN) { return Color.green; }
		else if(_a == cardColour.BLUE) { return Color.blue; }
		else if(_a == cardColour.CYAN) { return Color.cyan; }
		else if(_a == cardColour.YELLOW) { return Color.yellow; }
		else if(_a == cardColour.MAGENTA) { return Color.magenta; }
		else if(_a == cardColour.WHITE) { return Color.white; }
		else if(_a == cardColour.BLACK) { return Color.black; }
		return Color.clear;
	}

	public int getFace() { return face; }
	//public Position getPosition() { return position; }
	public void setFace(int _f) { face = _f; }
	//public void setPosition(int _x, int _y) { position.setX (_x); position.setY (_y); }
	public void print() { Debug.Log (face); }

	void OnMouseUp()
	{
		Debug.Log (x + " " + y + " " + face);
		Color _c = getColor((cardColour)face);
		renderer.material.color = _c;

	}
}