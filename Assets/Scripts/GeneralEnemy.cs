using UnityEngine;
using System.Collections;

public class GeneralEnemy : MonoBehaviour {
	
	public float idleSpeed;
	public float temp;
	public int Health = 3;

	public Vector2 initialPos;
	public Vector2 finalPos;
	public float maxMove = 5.0f;
	public Vector2 tempMove;
	public float moveSpeed = 0.1f;
	public string slideCurrent = "right";

	GameObject canvas;
	Score scoreText;
	public int timer1;
	public bool doDie;
	public bool audioPlayed;

	void Awake()
	{

	}

	//Called at start.
	void Start()
	{
		initialPos = new Vector2(this.transform.position.x, this.transform.position.y);
		canvas = GameObject.Find ("Score text");
		scoreText = canvas.GetComponent<Score>();
		timer1 = 15;
		doDie = false;
		audioPlayed = false;
	}
	
	//Called every frame.
	void Update() 
	{
		Die();
	}

	//Called every tick.
	void FixedUpdate()
	{
		Slide();
		if (doDie)
		{
			timer1--;
		}
		if (timer1 == 0)
		{
			Destroy (this.gameObject);
			scoreText.score = scoreText.score + 10;
			doDie = false;
			audioPlayed = false;
			return;
		}
	}

	//What happens when the enemy is shot.
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Laser")
		{
			Destroy (col.gameObject);
			Health -= 1;
		}
	}

	//What the enemy does on death.
	void Die()
	{
		if(Health == 0)
		{
			doDie = true;
			if (audioPlayed == false)
			{
				audioPlayed = true;
				this.audio.Play ();
			}
		}
	}

	void Slide()
	{
		finalPos = new Vector2(this.transform.position.x, this.transform.position.y);

		if(slideCurrent == "right" && (finalPos.x < initialPos.x + maxMove))
		{
			tempMove.x = moveSpeed;
			tempMove.x += finalPos.x;
			tempMove.y = finalPos.y;
			this.transform.position = tempMove;
		}
		if(slideCurrent == "right" && (finalPos.x >= initialPos.x + maxMove))
		{
			slideCurrent = "left";
		}

		if(slideCurrent == "left" && (finalPos.x > initialPos.x - maxMove))
		{
			tempMove.x = -moveSpeed;
			tempMove.x += finalPos.x;
			tempMove.y = finalPos.y;
			this.transform.position = tempMove;
		}
		if(slideCurrent == "left" && (finalPos.x <= initialPos.x - maxMove))
		{
			slideCurrent = "right";
		}
	}
}