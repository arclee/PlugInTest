using UnityEngine;

public class ShowMyPlayerSettings : MonoBehaviour {

	public MyPlayerSettings myPlayerSettings;

	void OnGUI(){

		GUILayout.Box(this.myPlayerSettings.bundleVersion);
		GUILayout.Box(CurrentBundleVersion.version);
	}
}
