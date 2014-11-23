using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public int score;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnGUI ()
	{
		GUI.Label (new Rect(55,8,100,100), score.ToString());
	}
}
