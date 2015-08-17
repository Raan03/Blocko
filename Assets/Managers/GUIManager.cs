using UnityEngine;

namespace Assets.Managers
{
    public class GuiManager : MonoBehaviour
    {
        private static GuiManager _instance;
        public GUIText BlockoText;
        public MeshRenderer CorporateLogo;
        public GUIText DistanceText;
        public GUIText GameOverText;
        public GUIText InstructionsText;
        public GUIText MaximumDistanceText;
        public GUIText MusicText;
        public GUIText PowerUpText;

        // Use this for initialization 
        private void Start()
        {
            _instance = this;

            GameEventManager.GameStart += GameStart;
            GameEventManager.GameOver += GameOver;

            GameOverText.enabled = false;
            CorporateLogo.enabled = true;

            _instance.MusicText.fontSize = Mathf.Min(Screen.height, Screen.width) /
     _instance.MusicText.fontSize;

            _instance.PowerUpText.fontSize = Mathf.Min(Screen.height, Screen.width) /
                                         _instance.PowerUpText.fontSize;

            _instance.MaximumDistanceText.fontSize = Mathf.Min(Screen.height, Screen.width) /
                                         _instance.MaximumDistanceText.fontSize;

            _instance.DistanceText.fontSize = Mathf.Min(Screen.height, Screen.width) /
                             _instance.DistanceText.fontSize;

            // for android. 
            if (Application.platform == RuntimePlatform.Android)
            {
                InstructionsText.text = "Double tap to start.";
            }
        }

        // Update is called once per frame 
        private void Update()
        {
            // Logic depends on our platform 
            switch (Application.platform)
            {
                case RuntimePlatform.Android:

                    // we tapped 
                    if (Input.touchCount > 0)
                    {
                        // we double tapped 
                        if (Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(0).tapCount == 2)
                        {
                            GameEventManager.TriggerGameStart();
                        }
                    }
                    break;

                default:
                    if (Input.GetButtonDown("Jump"))
                    {
                        GameEventManager.TriggerGameStart();
                    }
                    break;
            }
        }

        /// <summary>
        /// Handles what should be done when starting the game 
        /// </summary>
        private void GameStart()
        {
            CorporateLogo.enabled = false;
            GameOverText.enabled = false;
            InstructionsText.enabled = false;
            BlockoText.enabled = false;
            enabled = false;
        }

        // draw powerups text on screen 
        public static void SetPowerUps(int powerUp)
        {
            if (null == _instance)
            {
                return;
            }
            _instance.PowerUpText.text = string.Format("PowerUps: {0}", powerUp);

        }

        // draw distance text on screen 
        public static void SetDistance(float distance)
        {
            if (null == _instance)
            {
                return;
            }
            _instance.DistanceText.text = string.Format("Distance: {0}", distance.ToString("f0"));

        }

        // draw maximum achieved distance on screen 
        public static void SetMaximumDistance(float maximumDistance)
        {
            if (null == _instance)
            {
                return;
            }
            _instance.MaximumDistanceText.text = string.Format("Maximum Distance: {0}", maximumDistance.ToString("f0"));

        }

        // What is playing now, Einstein? 
        public static void SetMusic(string nowPlaying)
        {
            if (null == _instance)
            {
                return;
            }

            _instance.MusicText.text = string.Format("Now Playing: {0}", nowPlaying);
        }

        /// <summary>
        /// Handles what should be done when the Game is over 
        /// </summary>
        private void GameOver()
        {
            GameOverText.enabled = true;
            InstructionsText.enabled = true;
            enabled = true;
        }
    }
}
