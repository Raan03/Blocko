using UnityEngine;

// Example script showing how you can easily call into the AdMobPlugin.
namespace AssemblyCSharpfirstpass.Plugins.AdMobPlugin
{
	public class AdMobPluginDemoScript : MonoBehaviour
	{

		void Start ()
		{
			if (Application.platform == RuntimePlatform.Android) {
				AdMobPlugin.CreateBannerView ("ca-app-pub-5043402850278632/5433835428",
					AdMobPlugin.AdSize.banner,
					true);
				AdMobPlugin.RequestBannerAd (false);
			} else {
				print ("Skipping AdMob");
			}
		}

		void OnEnable ()
		{
			if (Application.platform == RuntimePlatform.Android) {
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
				AdMobPlugin.ReceivedAd -= HandleReceivedAd;
				AdMobPlugin.FailedToReceiveAd -= HandleFailedToReceiveAd;
				AdMobPlugin.ShowingOverlay -= HandleShowingOverlay;
				AdMobPlugin.DismissedOverlay -= HandleDismissedOverlay;
				AdMobPlugin.LeavingApplication -= HandleLeavingApplication;
			}
		}

		public void HandleReceivedAd ()
		{

		}

		public void HandleFailedToReceiveAd (string message)
		{

			print (message);
		}

		public void HandleShowingOverlay ()
		{

		}

		public void HandleDismissedOverlay ()
		{

		}

		public void HandleLeavingApplication ()
		{

		}
	}
}