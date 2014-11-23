using UnityEngine;
using System.Collections;

public class Heart1 : MonoBehaviour {
	
	GameObject player;
	CharacterMovement characterMovement;
	GameObject heart1;
	GameObject heart2;
	GameObject heart3;

	// Use this for initialization
	void Start () {

		player = GameObject.Find("Player");
		characterMovement = player.GetComponent<CharacterMovement>();
		heart1 = GameObject.Find("Heart1");
		heart2 = GameObject.Find("Heart2");
		heart3 = GameObject.Find("Heart3");
	}
	
	// Update is called once per frame
	void Update () {


		if (characterMovement.Health == 3) 
		{
			heart1.gameObject.SetActive(true);
			heart2.gameObject.SetActive(true);
			heart3.gameObject.SetActive(true);
			
		}
		if (characterMovement.Health == 2 || characterMovement.Health == 1 || characterMovement.Health == 0 ) 
		{
			heart1.gameObject.SetActive(false); 	
		}
		if (characterMovement.Health == 1 || characterMovement.Health == 0 ) 
		{
			heart2.gameObject.SetActive(false); 	
		}
		if (characterMovement.Health == 0 ) 
		{
			heart3.gameObject.SetActive(false);
		}
		
	}
	
}
