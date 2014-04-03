using UnityEngine;
using System.Collections;

public class MatchingGame : MonoBehaviour {
	public int width = 4;
	public int height = 4;
	public const int numCard = 16;
	public Timer matchingGameTimer;
	public Scoring matchingGameScore;
	public GameObject[,] screenCards;
	public Card[,] structureCards;

	//public Transform pcard;

	// Use this for initialization
	void Start () 
	{
		screenCards = new GameObject[width, height];
		structureCards = new Card[width, height];
		matchingGameTimer = new Timer ();
		matchingGameScore = new Scoring ();
		matchingGameTimer.setMaxTime (30);
		matchingGameScore.setID (3);
		setUpGame ();
		print ();

	}

	// Update is called once per frame
	void Update () {

	}

	void setUpGame()
	{
		for(int i = 0; i < width; i++)
		{
			for(int j = 0; j < height; j++)
			{
				structureCards[i, j] = new Card(i, j);
				screenCards[i, j] = (GameObject)Instantiate(Resources.Load("coverCard"), new Vector3(j*1.5f-2.24f, 0, i*2.3f-3.1f), Quaternion.identity);
				screenCards[i, j].GetComponent<Card>().x = i;
				screenCards[i, j].GetComponent<Card>().x = j;

				// Here I try to change the value, I use both constructor and public access
			}
		}

		int rand; 
		bool[] face = new bool[numCard];
		for(int i = 0; i < numCard; i++)
		{
			face[i] = false;
		}
		for(int i = 0; i < width; i++)
		{
			for(int j = 0; j < height; j++)
			{
				while(true)
				{	
					rand = Random.Range(0, numCard);
					if(face[rand] == false)
					{
						structureCards[i, j].setFace(rand%(numCard/2));
						face[rand] = true;

						Color _c = getColor((cardColour)structureCards[i, j].getFace());
						screenCards[i, j].renderer.material.color = _c; 
				
						break;
					}
				}
			}
		}
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


	void print()
	{
		for(int i = 0; i < width; i++)
		{
			for(int j = 0; j < height; j++)
			{

			}
		}	
	}
}
