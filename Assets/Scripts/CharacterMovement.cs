using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
	//controls
	public float speed;
    public KeyCode JumpControl;
    public KeyCode CrouchControl;
    public KeyCode PauseControl;
	public KeyCode LeftControl;
	public KeyCode RightControl;
	public KeyCode ShootControl;

	//
    public Vector2 moving;
    public float jumpStrength;
    public Vector2 jump;

	//Info gathering vars.
    public bool isGrounded;
	public bool isFacingLeft;
	public bool isFacingRight;
	public bool isAlive;

	//all of the jumping to check if the player is grounded.
	public LayerMask groundLayer;
	public Transform topLeft;
	public Transform bottomRight;

	//Shooting Vars.
	public Transform Laser_pref;
	public Transform Laser_pref_left;
	public Transform gunPointFacingRight;
	public int Health = 3;

	public bool stasis;
	public float stasisCooldown = 1.0f;
	public float stasisCooldownTimer;

	//Miscellaneous
	public bool paused = false;

	//Animation Vars
	Animator anim;
	bool jumped;
	float jumpTime;
	float jumpDelay = 0.5f;

	//Called at the beginning
    void Start()
    {
		isAlive = true;
		anim = gameObject.GetComponent<Animator>();
	}

	//Called every frame.
	void Update()
	{
		isGrounded = Physics2D.OverlapArea(topLeft.position, bottomRight.position,groundLayer);
	}
	
	//What to do when the player collides with a certain object.
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "EnemyLaser")
		{		
			Destroy (other.gameObject);
			Health -= 1;
		}

		if (other.gameObject.tag == "EnemyLaserLeft")
		{
			Destroy(other.gameObject);
			Health -= 1; 
		}

		if(other.gameObject.tag == "Enemy Melee")
		{
			Health -= 1;
		}
	}

	//Called every tick.
    void FixedUpdate()
	{
		MovementMethod();
        JumpMethod();
        PauseMethod();
		ShootMethod();
		DieMethod();
		StasisMethod();
    }

	//Determines how the player moves.
	void MovementMethod()
	{
		if(Input.GetKey(LeftControl))
		{
			isFacingLeft = true;
			isFacingRight = false;
			moving = new Vector2(-speed, rigidbody2D.velocity.y);
			rigidbody2D.velocity = moving;

		}
		else if(Input.GetKey(RightControl))
		{
			isFacingLeft = false;
			isFacingRight = true;
			moving = new Vector2(speed, rigidbody2D.velocity.y);
			rigidbody2D.velocity = moving;
		}
		else
		{
			moving = new Vector2(0, rigidbody2D.velocity.y);
			rigidbody2D.velocity = moving;
		}
	}

	//What to do when the player jumps.
    void JumpMethod()
    {
        if(Input.GetKey(JumpControl) && isGrounded)
        {
			jump = new Vector2(rigidbody2D.velocity.x, jumpStrength);
			jumpTime = jumpDelay;
			anim.SetBool("isJumping", true);
			rigidbody2D.velocity = jump;
        }
		jumpTime -= Time.deltaTime;

		if(jumpTime <= 0 && isGrounded)
		{
			anim.SetBool("isJumping", false);
		}
    }

	//How to pause the game (currently broken).
    void PauseMethod()
	{
        if(Input.GetKeyUp(KeyCode.Escape))
        {
			if(!paused)
			{
				Time.timeScale = 0;
				paused = true;
			}
			if(paused)
			{
				Time.timeScale = 1;
				paused = false;
			}
		}
    }

	//How the player fires lasers.
	void ShootMethod()
	{
		if(isFacingLeft && Input.GetKeyDown(ShootControl))
		{
			Instantiate(Laser_pref_left, new Vector2(gunPointFacingRight.transform.position.x, gunPointFacingRight.transform.position.y), Quaternion.identity);

		}
		if(isFacingRight && Input.GetKeyDown(ShootControl))
		{
			Instantiate(Laser_pref, new Vector2(gunPointFacingRight.transform.position.x, gunPointFacingRight.transform.position.y), Quaternion.identity);

		}

	}

	//What happens when the player dies.
	void DieMethod()
	{
		if (Health == 0)
		{
			Destroy (this.gameObject);
			isAlive = false;
		}
	}

	//When the player takes damage, he cannot take damage for a certain time after.
	void StasisMethod()
	{
		if(stasis)
		{
			if(stasisCooldownTimer > 0)
			{
				stasisCooldownTimer -= Time.deltaTime;
			}
			if(stasisCooldownTimer <= 0)
			{
				stasis = false;
				stasisCooldownTimer = stasisCooldown;
			}
		}
	}
    
}
