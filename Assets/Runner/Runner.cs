using UnityEngine;
using MA = AssemblyCSharp.Managers;

namespace AssemblyCSharp.Runner
{
	/// <summary>
	/// This handles all our "Cursor" object
	/// </summary>
	public class Runner : MonoBehaviour
	{
		public static float distanceTraveled;
		public float acceleration;
		public Vector3 jumpVelocity;
		public Vector3 boostVelocity;
		public float gameOverY;
		static int boosts;
		Vector3 _startPosition;
		bool _touchingPlatform;

		void FixedUpdate ()
		{
			// if we're on a platform, let him accelerate
			if (_touchingPlatform) {
				rigidbody.AddForce (acceleration, 0f, 0f, ForceMode.Acceleration);		
			}
		}

		void OnCollisionEnter ()
		{
			_touchingPlatform = true;
		}

		void OnCollisionExit ()
		{
			_touchingPlatform = false;
		}
		// Update is called once per frame
		void Update ()
		{
			switch (Application.platform) {
			case RuntimePlatform.Android:

			// seperate logic for seperate Platforms
			// for Android
				if (Input.touchCount > 0) {
					// we tapped
					if (_touchingPlatform) {
						rigidbody.AddForce (jumpVelocity, ForceMode.VelocityChange);
						_touchingPlatform = false;
					} else {
						if ((Input.GetTouch (0).phase == TouchPhase.Began) && (Input.GetTouch (0).tapCount == 2)) {
							// we double tapped
							if (boosts > 0) {
								// we use boost!
								rigidbody.AddForce (boostVelocity, ForceMode.VelocityChange);
								boosts -= 1;
								MA.GUIManager.SetPowerUps (boosts);
							}
						}
					}
				}
				break;
			default:
				if (Input.GetButtonDown ("Jump")) {
					if (_touchingPlatform) {
						rigidbody.AddForce (jumpVelocity, ForceMode.VelocityChange);	
						_touchingPlatform = false;
					} else if (boosts > 0) {
						rigidbody.AddForce (boostVelocity, ForceMode.VelocityChange);
						boosts -= 1;
						MA.GUIManager.SetPowerUps (boosts);
					}
				
				}
				break;
			}

			distanceTraveled = transform.localPosition.x;
			MA.GUIManager.SetDistance (distanceTraveled);
			// we fell into oblivion!
			if (transform.localPosition.y < gameOverY) {
				MA.GameEventManager.TriggerGameOver ();
			}
		}

		void Start ()
		{
			MA.GameEventManager.GameStart += GameStart;
			MA.GameEventManager.GameOver += GameOver;
			_startPosition = transform.localPosition;
			renderer.enabled = false;
			rigidbody.isKinematic = true;
			enabled = false;
		}

		void GameStart ()
		{
			boosts = 5;
			MA.GUIManager.SetPowerUps (boosts);
			distanceTraveled = 0f;
			MA.GUIManager.SetDistance (distanceTraveled);
			transform.localPosition = _startPosition;
			renderer.enabled = true;
			rigidbody.isKinematic = false;
			enabled = true;
		}

		public static void AddBoost ()
		{
			boosts += 1;
			MA.GUIManager.SetPowerUps (boosts);
		}

		void GameOver ()
		{
			renderer.enabled = false;
			rigidbody.isKinematic = true;
			enabled = false;
		}
	}
}