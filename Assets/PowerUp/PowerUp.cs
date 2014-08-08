using UnityEngine;
using System.Collections;

/// <summary>
/// Handles our PowerUp spawns
/// </summary>
public class PowerUp : MonoBehaviour
{
		public Vector3 offset, rotationVelocity;
		public float recycleOffset, spawnChance;
		// Use this for initialization
		void Start ()
		{
				GameEventManager.GameOver += GameOver;
				gameObject.SetActive (false);
		}

		public void SpawnIfAvailable (Vector3 position)
		{
				float RNG = Random.Range (0f, 100f);
				if (gameObject.activeSelf || spawnChance < RNG) {
						return;		
				}
				transform.localPosition = position + offset;
				gameObject.SetActive (true);
		}
		
		private void GameOver ()
		{
				gameObject.SetActive (false);
		}

		void Update ()
		{
				if (transform.localPosition.x + recycleOffset < Runner.distanceTraveled) {
						gameObject.SetActive (false);
						return;
				}
				transform.Rotate (rotationVelocity * Time.deltaTime);
		}
		void OnTriggerEnter ()
		{
				Runner.AddBoost ();
				gameObject.SetActive (false);
		}
}
