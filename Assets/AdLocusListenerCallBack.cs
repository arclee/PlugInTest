using UnityEngine;
using System.Collections;

public class AdLocusListenerCallBack : AndroidJavaProxy {

	public AdLocusListenerCallBack():base("com.ad.adlocus.CAdLocusListenerCallBack")
	{

	}

	void onReceiveAd()
	{

	}

	void onFailedToReceiveAd(int errorcode)
	{
		Debug.Log("onFailedToReceiveAd" + errorcode.ToString());
		switch(errorcode)
		{
			case 1:
			{
				break;
			}
			case 2:
			{
				break;
			}
			case 3:
			{
				break;
			}
			case 4:
			{
				break;
			}
			default:
			{
			
				break;
			}
		};
	}
}
