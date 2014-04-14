using UnityEngine;
using System.Collections;

public class SheepSpawner : MonoBehaviour {
	public GameObject SheepPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnSheep()
	{
		Instantiate (SheepPrefab, this.transform.position, this.transform.rotation);
	}
}
