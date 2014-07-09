using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using System.Reflection;

public class main2 : MonoBehaviour {
	
	private bool isAdInital = false;
	private AndroidJavaObject AdJo = null;
	private AdVungleCallBack AdListenerCB = null;

	public string appid = "";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI ()
	{
	
		
		if (GUI.Button(new Rect (0, 100, 100, 100), "AdVungle init"))
		{
			Debug.Log(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
			if (!isAdInital)
			{
				AndroidJavaClass player = new AndroidJavaClass( "com.unity3d.player.UnityPlayer" );
				AndroidJavaObject activity = player.GetStatic<AndroidJavaObject>("currentActivity");
				AdJo = new AndroidJavaObject("com.ad.advungle.CAdVungle", activity);
				AdListenerCB = new AdVungleCallBack();
				isAdInital = true;
			}
			
			AdJo.Call("SetAppID", appid); 
			AdJo.Call("SetListenerCB", AdListenerCB); 
			AdJo.Call("Inital"); 
		}
		
		if (GUI.Button(new Rect (0, 200, 100, 100), "AdVungle show"))
		{
			AdJo.Call("PlayAD", true, true); 
		}
		
		if (GUI.Button(new Rect (0, 300, 100, 100), "AdVungle hide"))
		{
			//AdJo.Call("HideAD"); 
		}

	}
}
