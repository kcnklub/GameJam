using UnityEngine;
using System.Collections;

public class GeneralEnemy : MonoBehaviour {
	
	public float idleSpeed;
	public float temp;
	public int health;

	GameObject canvas;
	Score scoreText;

	void Awake()
	{

	}

	// Use this for initialization
	void Start ()
	{
		canvas = GameObject.Find ("Score text");
		scoreText = canvas.GetComponent<Score>();
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
			scoreText.score = scoreText.score + 10;
		}
	}

}
