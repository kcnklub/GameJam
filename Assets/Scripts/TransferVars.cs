using UnityEngine;
using System.Collections;

public class TransferVars : MonoBehaviour {

	GameObject source;
	Score nScore;
	public float permaScore;

	// Use this for initialization
	void Start () {
	
		source = GameObject.Find("Score text");
		nScore = source.GetComponent<Score>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		permaScore = nScore.score;
		DontDestroyOnLoad(this.gameObject);
	}
}
