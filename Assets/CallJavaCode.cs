using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

public class CallJavaCode : MonoBehaviour {

	[DllImport("javabridge")]
	private static extern IntPtr getCacheDir();

	private string cacheDir = "Push to get cache dir";

	private bool isAdlocusInital = false;
	private AndroidJavaObject AdLocusJo = null;
	private AdLocusListenerCallBack AdListenerCB = null;
	void OnGUI ()
	{
		if (GUI.Button(new Rect (0, 0, 100, 100), cacheDir))
		{
			IntPtr stringPtr = getCacheDir();
			Debug.Log("stringPtr = " +stringPtr);
			String cache = Marshal.PtrToStringAnsi(stringPtr);
			Debug.Log("getCacheDir returned " + cache);
			cacheDir = cache;
		}
		
		if (GUI.Button(new Rect (0, 100, 100, 100), "AdLocus init"))
		{
			if (!isAdlocusInital)
			{
				AndroidJavaClass player = new AndroidJavaClass( "com.unity3d.player.UnityPlayer" );
				AndroidJavaObject activity = player.GetStatic<AndroidJavaObject>("currentActivity");
				AdLocusJo = new AndroidJavaObject("com.ad.adlocus.CAdLocus", activity);
				AdListenerCB = new AdLocusListenerCallBack();
				isAdlocusInital = true;
			}

			 
			AdLocusJo.Call("SetListenerCB", AdListenerCB); 
			AdLocusJo.Call("SetAppID", "a9f0973dc1d03695be3f951c20caae6d162e7e6f"); 
			AdLocusJo.Call("SetTestMode", false); 
			AdLocusJo.Call("Inital"); 
		}

		if (GUI.Button(new Rect (0, 200, 100, 100), "AdLocus show"))
		{
			AdLocusJo.Call("ShowAD"); 
		}
		
		if (GUI.Button(new Rect (0, 300, 100, 100), "AdLocus hide"))
		{
			AdLocusJo.Call("HideAD"); 
		}

	}
}
