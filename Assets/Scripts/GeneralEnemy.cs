using UnityEngine;
using System.Collections;

public class GeneralEnemy : MonoBehaviour {
	
	public float idleSpeed;
	public float temp;
	public int health;

	void Awake()
	{

	}

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		die ();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Laser")
		{
			health = health - 1;
		}
	}

	void die()
	{
		if(health == 0)
		{
			Destroy(this.gameObject);
		}
	}

}
