using UnityEngine;
using System.Collections;

public class Heart1 : MonoBehaviour {
	
	GameObject player;
	CharacterMovement characterMovement;


	// Use this for initialization
	void Start () {

		player = GameObject.Find("Player");
		characterMovement = player.GetComponent<CharacterMovement>();

	
	}
	
	// Update is called once per frame
	void Update () {



		if (characterMovement.Health == 2 || characterMovement.Health == 1 || characterMovement.Health == 0 ) 
		{
			Debug.Log("het");
			this.gameObject.SetActive(false); 	
		}

		if (characterMovement.Health == 3) 
		{
			this.gameObject.SetActive(true); 	
		}
	
	}


}
