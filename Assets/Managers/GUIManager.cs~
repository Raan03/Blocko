using UnityEngine;
using GA = AssemblyCSharpfirstpass.Plugins.GoogleAnalytics.GoogleAnalytics;
using AM = AssemblyCSharpfirstpass.Plugins.AdMobPlugin.AdMobPluginDemoScript;

namespace AssemblyCSharp.Managers
{
		public class GUIManager : MonoBehaviour
		{
				public GUIText powerUpText, distanceText, maximumDistanceText, gameOverText, instructionsText, blockoText, musicText;
				public MeshRenderer corporateLogo;
				static GUIManager instance = null;
				GA _google;


				// Use this for initialization
				void Start ()
				{
						instance = this;
						GameEventManager.GameStart += GameStart;
						GameEventManager.GameOver += GameOver;
						gameOverText.enabled = false;
						corporateLogo.enabled = true;
						if (Application.platform == RuntimePlatform.Android) {
								instructionsText.text = "Double tap to start.";
						}

						if (null != GA.instance) {
								//_google = 
								_google = GA.instance;		
								_google.LogScreen ("Accessed Main Menu.");
						}

				}
	
				// Update is called once per frame
				void Update ()
				{
						// Logic depends on our platform
						switch (Application.platform) {
						case RuntimePlatform.Android:		
				// we tapped
								if (Input.touchCount > 0) {			
										// we double tapped
										if (Input.GetTouch (0).phase == TouchPhase.Began && Input.GetTouch (0).tapCount == 2) {
												GameEventManager.TriggerGameStart ();
										}
								}
								break;
						default:
								if (Input.GetButtonDown ("Jump")) {
										GameEventManager.TriggerGameStart ();
								}
								break;
						}
				}

				/// <summary>
				/// Handles what should be done when starting the game
				/// </summary>
				void GameStart ()
				{

						corporateLogo.enabled = false;
						gameOverText.enabled = false;
						instructionsText.enabled = false;
						blockoText.enabled = false;
						enabled = false;
						if (GA.instance)
								GA.instance.LogScreen ("Started game.");
				}

				public static void SetPowerUps (int powerUp)
				{
						instance.powerUpText.text = string.Format ("PowerUps: {0}", powerUp.ToString ());
				}

				public static void SetDistance (float distance)
				{
						instance.distanceText.text = string.Format ("Distance: {0}", distance.ToString ("f0"));
				}
				public static void SetMaximumDistance (float maximumDistance)
				{
						instance.maximumDistanceText.text = string.Format ("Maximum Distance: {0}", maximumDistance.ToString ("f0"));
				}
				public static void SetMusic (string nowPlaying)
				{
						if (null != instance) {
								instance.musicText.text = string.Format ("Now Playing: {0}", nowPlaying);
						}
				}

				/// <summary>
				/// Handles what should be done when the Game is over
				/// </summary>
				void GameOver ()
				{
						gameOverText.enabled = true;
						instructionsText.enabled = true;
						enabled = true;
						if (null != GA.instance)
								GA.instance.LogScreen (
					string.Format ("Has died. Distance: {0} PowerUps: {1}", 
						instance.distanceText.text, 
						instance.powerUpText.text));
				}
		}
}