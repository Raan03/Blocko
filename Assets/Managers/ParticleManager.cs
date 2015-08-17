using UnityEngine;

namespace Assets.Managers
{
	/// <summary>
	/// Handles our particles to look less bland
	/// </summary>
	public class ParticleManager : MonoBehaviour
	{
		public ParticleSystem[] ParticleSystems;
		// Use this for initialization
		void Start ()
		{
			GameEventManager.GameStart += GameStart;
			GameEventManager.GameOver += GameOver;
			GameOver ();
		}

		void GameStart ()
        { 
            foreach(var pSystem in ParticleSystems)
            {
                pSystem.Clear();
                pSystem.enableEmission = true;
            }
		}

		void GameOver ()
		{
		    foreach (var pSystem in ParticleSystems)
		    {
		        pSystem.enableEmission = false;
		    }
		}
		// Update is called once per frame
		void Update ()
		{
	
		}
	}
}