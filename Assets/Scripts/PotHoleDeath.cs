using UnityEngine;
using System.Collections;

public class PotHoleDeath : MonoBehaviour {

	CharacterMovement characterMovement;
	private GameObject Player;

	// Use this for initialization
	void Start () {
	
		Player = GameObject.FindWithTag("Player");
		characterMovement = Player.GetComponent<CharacterMovement>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if(col.gameObject.tag == "Player")
		{
			characterMovement.Health = 0;
		}	

		//Destroy(col.gameObject);
		
		
	}

}
