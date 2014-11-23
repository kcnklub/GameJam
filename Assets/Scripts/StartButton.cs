using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour
{
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
	}
}