using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour {

	public static void joueTour()
	{
		//On arrive dans le tour
		GUI.Window(0,new Rect(new Vector2(200,100), new Vector2(200,100)),clicked,"Congratz");
	}

	private static void clicked(int c)
	{
		Debug.Log ("clicked");
	}
		
}
