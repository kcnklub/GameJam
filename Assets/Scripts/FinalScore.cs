using UnityEngine;
using UnityEngine.UI;
using System.Collections;
	
public class FinalScore : MonoBehaviour {

	GameObject objectVars;
	TransferVars finalVars;
	Text text;
	public float endScore;

	// Use this for initialization
	void Start () {
	
		objectVars = GameObject.Find("VariablesToTransfer");
		finalVars = objectVars.GetComponent<TransferVars>();
		text = GetComponent<Text>();
		endScore = finalVars.permaScore;
	}
	
	// Update is called once per frame
	void Update () {
	
		text.text = "Score: " + endScore;

	}
}
