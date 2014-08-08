using UnityEngine;

public class GoogleAnalytics : MonoBehaviour
{
	
		public string propertyID;
	
		public static GoogleAnalytics instance;
	
		public string bundleID;
		public string appName;
		public string appVersion;
	
		string _screenRes;
		string _clientID;
	
		void Awake ()
		{
				if (instance)
						DestroyImmediate (gameObject);
				else {
						DontDestroyOnLoad (gameObject);
						instance = this;
				}
		}
	
		void Start ()
		{
	
				_screenRes = Screen.width + "x" + Screen.height;
		
				_clientID = SystemInfo.deviceUniqueIdentifier;
			
		}

		public void LogScreen (string title)
		{
		
				title = WWW.EscapeURL (title);
		
				string url = "http://www.google-analytics.com/collect?v=1&ul=en-us&t=appview&sr=" 
						+ _screenRes + "&an=" + WWW.EscapeURL (appName) 
						+ "&a=448166238&tid=" + propertyID 
						+ "&aid=" + bundleID + "&cid=" + WWW.EscapeURL (_clientID) 
						+ "&_u=.sB&av=" + appVersion + "&_v=ma1b3&cd=" 
						+ title + "&qt=2500&z=185";
		
				WWW request = new WWW (url);
		
		}
	
	
}