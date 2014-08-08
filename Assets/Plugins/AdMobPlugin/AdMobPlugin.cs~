using System;
using UnityEngine;

// The AdMob Plugin used to call into the AdMob Android Unity library.
public class AdMobPlugin : MonoBehaviour
{

		// Defines string values for supported ad sizes.
		public class AdSize
		{
				string _adSize;
				AdSize (string value)
				{
						this._adSize = value;
				}

				public override string ToString ()
				{
						return _adSize;
				}

				public static AdSize banner = new AdSize ("BANNER");
				public static AdSize mediumRectangle = new AdSize ("IAB_MRECT");
				public static AdSize iabBanner = new AdSize ("IAB_BANNER");
				public static AdSize leaderboard = new AdSize ("IAB_LEADERBOARD");
				public static AdSize smartBanner = new AdSize ("SMART_BANNER");
		}

		// These are the ad callback events that can be hooked into.
		public static e vent Action ReceivedAd = delegate {
				};
		public static e vent Action<string> FailedToReceiveAd = delegate {
				};
		public static e vent Action ShowingOverlay = delegate {
				};
		public static e vent Action DismissedOverlay = delegate {
				};
		public static e vent Action LeavingApplication = delegate {
				};

		void Awake ()
		{
				if (Application.platform == RuntimePlatform.Android) {
						gameObject.name = GetType ().ToString ();
						SetCallbackHandlerName (gameObject.name);
						DontDestroyOnLoad (this);
				}
		}

		// Create a banner view and add it into the view hierarchy.
		public static void CreateBannerView (string publisherId, AdSize adSize, bool positionAtTop)
		{
				#if UNITY_ANDROID
				AndroidJavaClass playerClass = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
				AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject> ("currentActivity");
				AndroidJavaClass pluginClass = new AndroidJavaClass ("com.google.unity.AdMobPlugin");
				pluginClass.CallStatic ("createBannerView",
			new object[4] {activity, publisherId, adSize.ToString (), positionAtTop});
				#endif
		}

		// Request a new ad for the banner view without any extras.
		public static void RequestBannerAd (bool isTesting)
		{
				#if UNITY_ANDROID
				AndroidJavaClass pluginClass = new AndroidJavaClass ("com.google.unity.AdMobPlugin");
				pluginClass.CallStatic ("requestBannerAd", new object[1] {isTesting});
#endif
		}


		// Request a new ad for the banner view with extras.
		public static void RequestBannerAd (bool isTesting, string extras)
		{
				#if UNITY_ANDROID
				AndroidJavaClass pluginClass = new AndroidJavaClass ("com.google.unity.AdMobPlugin");
				pluginClass.CallStatic ("requestBannerAd", new object[2] {isTesting, extras});
#endif
		}

		// Set the name of the callback handler so the right component gets ad callbacks.
		public static void SetCallbackHandlerName (string callbackHandlerName)
		{
				#if UNITY_ANDROID
				AndroidJavaClass pluginClass = new AndroidJavaClass ("com.google.unity.AdMobPlugin");
				pluginClass.CallStatic ("setCallbackHandlerName", new object[1] {callbackHandlerName});
#endif
		}

		// Hide the banner view from the screen.
		public static void HideBannerView ()
		{
				#if UNITY_ANDROID
				AndroidJavaClass pluginClass = new AndroidJavaClass ("com.google.unity.AdMobPlugin");
				pluginClass.CallStatic ("hideBannerView");
#endif
		}

		// Show the banner view on the screen.
		public static void ShowBannerView ()
		{
				#if UNITY_ANDROID
				AndroidJavaClass pluginClass = new AndroidJavaClass ("com.google.unity.AdMobPlugin");
				pluginClass.CallStatic ("showBannerView");
#endif
		}

		public void OnReceiveAd (string unusedMessage)
		{
				ReceivedAd ();
		}

		public void OnFailedToReceiveAd (string message)
		{
				FailedToReceiveAd (message);
		}

		public void OnPresentScreen (string unusedMessage)
		{
				ShowingOverlay ();
		}

		public void OnDismissScreen (string unusedMessage)
		{
				DismissedOverlay ();
		}

		public void OnLeaveApplication (string unusedMessage)
		{
				LeavingApplication ();
		}
}