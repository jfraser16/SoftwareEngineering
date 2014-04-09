using UnityEngine;
using System.Collections;

public class MatchingGame : GameManager {
	public int width = 4;
	public int height = 4;
	public const int numCard = 16;
	public GameObject[,] cardObject;
	public Card[,] cardScript;
	public static clickState click_state;
	public static cardColour value1;
	public static cardColour value2;
	public int score = 0;
	public bool outOfTime = false;

	void Start () 
	{
		cardObject = new GameObject[width, height];
		cardScript = new Card[width, height];
		setUpGame ();
		click_state = clickState.DEFAULT;
		CQTimer.setMaxTime (30);
		CQTimer.setStartTime ();
	}

	new public void Update()
	{
		base.Update ();
	}

	public override void RunGame () 
	{
		outOfTime = CQTimer.updateTimer ();
		if((value1 == value2)&&(click_state == clickState.SECOND_CLICK))
		{
			Debug.Log("Yay");
			score++;
			Scoring.setScore(Application.loadedLevelName, score);
			StartCoroutine (justWait (0));
		}
		else if((value1 != value2)&&(click_state == clickState.SECOND_CLICK))
		{
			Debug.Log("Aww");
			StartCoroutine (justWait (1));
		}
	}
	
	IEnumerator justWait(int _i)
	{
		if(_i == 0)
		{
			yield return new WaitForSeconds (0.1f);
			for(int i = 0; i < width; i++)
			{
				for(int j = 0; j < height; j++)
				{
					if(cardScript[i, j].face == value1) cardObject[i, j].renderer.enabled = false;
				}
			}
			click_state = clickState.DEFAULT;
		}
		else if(_i == 1)
		{
			yield return new WaitForSeconds (0.5f);
			click_state = clickState.DEFAULT;
			for(int i = 0; i < width; i++)
			{
				for(int j = 0; j < height; j++)
				{
					cardScript[i, j].renderer.material.color = Color.gray;
				}
			}
		}
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
						cardScript[i, j].renderer.material.color = Color.gray;
						face[rand] = true;
						break;
					}
				}
			}
		}
	}
}
