using UnityEngine;
using System.Collections;

public class MatchingGame : MonoBehaviour {
	public int width = 4;
	public int height = 4;
	public const int numCard = 16;
	public Timer matchingGameTimer;
	public Scoring matchingGameScore;
	public GameObject[,] cardObject;
	public Card[,] cardScript;

	// Use this for initialization
	void Start () 
	{
		cardObject = new GameObject[width, height];
		cardScript = new Card[width, height];
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
				cardObject[i, j] = (GameObject)Instantiate(Resources.Load("coverCard"), new Vector3(j*1.5f-2.24f, 0, i*2.3f-3.1f), Quaternion.identity);
				cardScript[i, j] = cardObject[i, j].GetComponent<Card>();
                cardScript[i, j].SetPosition(i, j);
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
						cardScript[i, j].setFace((cardColour)(rand%(numCard/2)));
						face[rand] = true;
						break;
					}
				}
			}
		}
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
