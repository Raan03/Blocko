using Assets.Managers;
using UnityEngine;

namespace Assets.Runner
{
    /// <summary>
    /// This handles all our "Cursor" object 
    /// </summary>
    public class Runner : MonoBehaviour
    {
        public static float DistanceTraveled;
        public float Acceleration = 5f;
        public Vector3 JumpVelocity;
        public Vector3 BoostVelocity;
        public float GameOverY;
        private static int _boosts;
        private Vector3 _startPosition;
        private float _maximumDistanceTraveled;
        private bool _touchingPlatform;

        /// <summary>
        /// FixedUpdate = Same as Update, except give room for physics to handle
        /// </summary>
        private void FixedUpdate()
        {
            // if we're on a platform, let him accelerate 
            if (_touchingPlatform)
            {
                GetComponent<Rigidbody>().AddForce(Acceleration, 0f, 0f, ForceMode.Acceleration);
            }
        }

        private void OnCollisionEnter()
        {
            _touchingPlatform = true;
        }

        private void OnCollisionExit()
        {
            _touchingPlatform = false;
        }

        // Update is called once per frame 
        private void Update()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.Android:

                    // seperate logic for seperate Platforms for Android 
                    if (Input.touchCount > 0)
                    {
                        // we tapped 
                        if (_touchingPlatform)
                        {
                            GetComponent<Rigidbody>().AddForce(JumpVelocity, ForceMode.VelocityChange);
                            _touchingPlatform = false;
                        }
                        else
                        {
                            if ((Input.GetTouch(0).phase == TouchPhase.Began) && (Input.GetTouch(0).tapCount == 2))
                            {
                                // we double tapped 
                                if (_boosts > 0)
                                {
                                    // we use boost! 
                                    GetComponent<Rigidbody>().AddForce(BoostVelocity, ForceMode.VelocityChange);
                                    _boosts -= 1;
                                    GuiManager.SetPowerUps(_boosts);
                                }
                            }
                        }
                    }
                    break;

                default:
                    if (Input.GetButtonDown("Jump"))
                    {
                        if (_touchingPlatform)
                        {
                            GetComponent<Rigidbody>().AddForce(JumpVelocity, ForceMode.VelocityChange);
                            _touchingPlatform = false;
                        }
                        else if (_boosts > 0)
                        {
                            GetComponent<Rigidbody>().AddForce(BoostVelocity, ForceMode.VelocityChange);
                            _boosts -= 1;
                            GuiManager.SetPowerUps(_boosts);
                        }
                    }
                    break;
            }

            DistanceTraveled = transform.localPosition.x;
            if (DistanceTraveled > _maximumDistanceTraveled)
            {
                _maximumDistanceTraveled = DistanceTraveled;
            }
            GuiManager.SetDistance(DistanceTraveled);
            GuiManager.SetMaximumDistance(_maximumDistanceTraveled);

            // we fell into oblivion! 
            if (transform.localPosition.y < GameOverY)
            {
                GameEventManager.TriggerGameOver();
            }
        }

        private void Start()
        {
            GameEventManager.GameStart += GameStart;
            GameEventManager.GameOver += GameOver;

            _startPosition = transform.localPosition;
            GetComponent<Renderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            enabled = false;
        }

        private void GameStart()
        {
            _boosts = 5;
            DistanceTraveled = 0f;

            GuiManager.SetPowerUps(_boosts);
            GuiManager.SetDistance(DistanceTraveled);

            transform.localPosition = _startPosition;

            GetComponent<Renderer>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
            enabled = true;

            LoadMaximumDistanceTraveled();
        }

        public static void AddBoost()
        {
            _boosts += 1;
            GuiManager.SetPowerUps(_boosts);
        }

        private void GameOver()
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            enabled = false;
            SaveMaximumDistanceTraveled();
        }

        private void LoadMaximumDistanceTraveled()
        {
            _maximumDistanceTraveled = PlayerPrefs.GetInt("_maximumDistanceTraveled", 0);
        }

        private void SaveMaximumDistanceTraveled()
        {
            PlayerPrefs.SetInt("_maximumDistanceTraveled", (int)_maximumDistanceTraveled);
        }
    }
}
