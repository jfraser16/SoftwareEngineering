using UnityEngine;
using System.Collections;

public class Position{

	public int x;
	public int y;

	public Position(int _a, int _b)
	{
		x = _a;
		y = _b;
	}

	public void setX(int _x) { x = _x;	}
	public void setY(int _y) {	y = _y;	}

}
