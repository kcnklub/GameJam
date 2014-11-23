using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{

    public float speed;

	//controls
    public KeyCode JumpControl;
    public KeyCode DuckControl;
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

	//Miscellaneous
	public bool paused = false;

	//Animation Vars
	Animator anim;
	bool jumped;
	float jumpTime;
	float jumpDelay = 0.5f;
	 




    void Start()
    {
		isAlive = true;
		anim = gameObject.GetComponent<Animator>();
	}

	void Update()
	{
		isGrounded = Physics2D.OverlapArea(topLeft.position, bottomRight.position,groundLayer);
	}

    void FixedUpdate()
    {
        jumpMethod();
        duck();
        openPause();
		movement();
		shoot ();
		Die ();
    }

	/////////////////////////////////////////////////////////////////
	///Starting the methods that are going to be called.
	void movement()
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

    void jumpMethod()
    {
        if(Input.GetKey(JumpControl) && isGrounded )
        {
			jump = new Vector2(rigidbody2D.velocity.x, jumpStrength);
			jumpTime = jumpDelay;
			anim.SetBool("isJumping", true);
			rigidbody2D.velocity = jump;

            Debug.Log("The Character is now jumping");
        }

		jumpTime -= Time.deltaTime;

		if(jumpTime <= 0 && isGrounded)
		{
			anim.SetBool("isJumping", false);
		}

    }

    void duck()
    {
        if (Input.GetKey(DuckControl) && isGrounded)
        {
            Debug.Log("The Character is now Ducking");
        }
    }

    void openPause()
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
	void shoot()
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

	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.tag == "Enemy Laser") {
		
			Destroy (other.gameObject);
			Health = Health - 1;
		}
	 }

	void Die(){

		if (Health == 0) {

			Destroy (this.gameObject);
			isAlive = false;
		}

	}
    
}
