using UnityEngine;
using System.Collections;

public class Heart3 : MonoBehaviour {

	GameObject player;
	CharacterMovement characterMovement;
	
	
	// Use this for initialization
	void Start () {
		
		player = GameObject.Find("Player");
		characterMovement = player.GetComponent<CharacterMovement>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (characterMovement.Health == 0) 
		{
			this.gameObject.SetActive(false); 	
		}
		
		if (characterMovement.Health == 1) 
		{
			this.gameObject.SetActive(true); 	
		}
		
	}
}
