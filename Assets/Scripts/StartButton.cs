using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour
{
	GameObject permaScore;

	void FixedUpdate()
	{
		if (gameObject.name == "Start")
		{
			Application.LoadLevel ("firstLevel");
		}
		if (gameObject.name == "Exit")
		{
			Application.Quit();
		}
		if (gameObject.name == "Restart")
		{
			Application.LoadLevel ("firstLevel");
		}

	}
}