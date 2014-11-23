using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public float Speed;

	// Use this for initialization
	void Start () {

		Destroy(this.gameObject, 5);
	
	}
	
	// Update is called once per frame
	void Update () {

		moveRight();
	
	}

	void moveRight()
	{
		transform.Translate (new Vector2(Speed * Time.deltaTime, 0));
	}


}
