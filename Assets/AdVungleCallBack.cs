using UnityEngine;
using System.Collections;

public class AdVungleCallBack : AndroidJavaProxy {
	
	public AdVungleCallBack():base("com.ad.advungle.CAdVungleListenerCallBack")
	{
		
	}
	
	
	// Called each time a video completes. isCompletedView is true if the video was not skipped.
	public void onVideoView(bool isCompletedView, int watchedMillis, int videoDurationMillis)
	{
		Debug.Log("unity onVideoView");
	}
	
	// Called before playing an ad.
	public void onAdStart()
	{
		Debug.Log("unity onAdStart");

	}
	
	// Called when the user leaves the ad and control is returned to your application.
	public void onAdEnd()
	{
		
		Debug.Log("unity onAdEnd");
	}
	
	// Called when ad is downloaded and ready to be played.
	public void onCachedAdAvailable()
	{
		Debug.Log("unity onCachedAdAvailable");

	}
	
	// TODO Auto-generated method stub.
	void onAdUnavailable(string arg0)
	{
		Debug.Log("unity onAdUnavailable");

	}
}
