using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class UpdateMyPlayerSettings {

	private const string MY_SETTINGS_PATH = "Assets/MyPlayerSettings.asset";

	private static MyPlayerSettings settings;

	static UpdateMyPlayerSettings(){

		EditorApplication.update += AppUpdate;

		settings = (MyPlayerSettings)AssetDatabase.LoadAssetAtPath(MY_SETTINGS_PATH , typeof(MyPlayerSettings));

		if(!settings){

			settings = ScriptableObject.CreateInstance<MyPlayerSettings>();
			settings.bundleVersion = PlayerSettings.bundleVersion;
			AssetDatabase.CreateAsset(settings , MY_SETTINGS_PATH);
		}
	}

	static void AppUpdate(){

		settings.bundleVersion = PlayerSettings.bundleVersion;
	}
}
