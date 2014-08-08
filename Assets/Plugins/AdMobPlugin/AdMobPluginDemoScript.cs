using UnityEngine;

// Example script showing how you can easily call into the AdMobPlugin.
public class AdMobPluginDemoScript : MonoBehaviour
{

		void Start ()
		{
				if (Application.platform == RuntimePlatform.Android) {
						print ("Started");
						AdMobPlugin.CreateBannerView ("ca-app-pub-5043402850278632/5433835428",
                                     AdMobPlugin.AdSize.banner,
                                     true);
						print ("Created Banner View");
						AdMobPlugin.RequestBannerAd (false);
						print ("Requested Banner Ad");
				} else {
						print ("Skipping AdMob");
				}
		}

		void OnEnable ()
		{
		if (Application.platform == RuntimePlatform.Android) {
						print ("Registering for AdMob Events");
						AdMobPlugin.ReceivedAd += HandleReceivedAd;
						AdMobPlugin.FailedToReceiveAd += HandleFailedToReceiveAd;
						AdMobPlugin.ShowingOverlay += HandleShowingOverlay;
						AdMobPlugin.DismissedOverlay += HandleDismissedOverlay;
						AdMobPlugin.LeavingApplication += HandleLeavingApplication;
				}
		}

		void OnDisable ()
		{
		if (Application.platform == RuntimePlatform.Android) {
						print ("Unregistering for AdMob Events");
						AdMobPlugin.ReceivedAd -= HandleReceivedAd;
						AdMobPlugin.FailedToReceiveAd -= HandleFailedToReceiveAd;
						AdMobPlugin.ShowingOverlay -= HandleShowingOverlay;
						AdMobPlugin.DismissedOverlay -= HandleDismissedOverlay;
						AdMobPlugin.LeavingApplication -= HandleLeavingApplication;
				}
		}

		public void HandleReceivedAd ()
		{
				print ("HandleReceivedAd event received");
		}

		public void HandleFailedToReceiveAd (string message)
		{
				print ("HandleFailedToReceiveAd event received with message:");
				print (message);
		}

		public void HandleShowingOverlay ()
		{
				print ("HandleShowingOverlay event received");
		}

		public void HandleDismissedOverlay ()
		{
				print ("HandleDismissedOverlay event received");
		}

		public void HandleLeavingApplication ()
		{
				print ("HandleLeavingApplication event received");
		}
}