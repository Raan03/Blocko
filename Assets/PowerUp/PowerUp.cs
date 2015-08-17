using Assets.Managers;
using UnityEngine;

namespace Assets.PowerUp
{
    /// <summary>
    /// Handles our PowerUp (PUP) spawns 
    /// </summary>
    public class PowerUp : MonoBehaviour
    {
        public Vector3 Offset;
        public Vector3 RotationVelocity;
        public float RecycleOffset;
        public float SpawnChance;

        // Use this for initialization 
        private void Start()
        {
            GameEventManager.GameOver += GameOver;
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Will spawn our powerup if the RNG gods are in our favor 
        /// </summary>
        /// <param name="position">
        /// </param>
		public void SpawnIfAvailable(Vector3 position)
        {
            float rng = Random.Range(0f, 100f) / 100;
            if (gameObject.activeSelf || SpawnChance <= rng)
            {
                return;
            }
            transform.localPosition = position + Offset;
            gameObject.SetActive(true);
        }

        private void GameOver()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (transform.localPosition.x + RecycleOffset < Runner.Runner.DistanceTraveled)
            {
                gameObject.SetActive(false);
                return;
            }
            transform.Rotate(RotationVelocity * Time.deltaTime);
        }

        private void OnTriggerEnter()
        {
            Runner.Runner.AddBoost();
            gameObject.SetActive(false);
        }
    }
}
