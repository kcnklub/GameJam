using UnityEngine;
using System.Collections;

public class LaserMoveLeft : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	
		Destroy(this.gameObject, 1.5f);

	}
	
	// Update is called once per frame
	void Update () {
	
		moveLeft();

	}

	void moveLeft()
	{
		transform.Translate (new Vector2(speed * Time.deltaTime, 0));
	}
}
