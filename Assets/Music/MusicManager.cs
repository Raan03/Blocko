using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Our Music Manager -- for handling Music Logic
/// </summary>
public class MusicManager : MonoBehaviour
{
		static List<int> played = new List<int> ();
		public List<AudioClip> myMusic;
		void Start ()
		{
				PlayRandomMusic ();
		}
		void Update ()
		{
				if (!this.audio.isPlaying) {
						PlayRandomMusic ();
				}
		}

		void PlayRandomMusic ()
		{
				if (myMusic.Count != 0) {
						// We played all available music, reset the list!
						if (played.Count == myMusic.Count)
								played = new List<int> ();
						int RNG = Random.Range (0, myMusic.Count);
						while (played.Contains(RNG)) {
								RNG = Random.Range (0, myMusic.Count);
						}
						played.Add (RNG);

						audio.clip = myMusic [RNG];
						audio.Play ();
						try {
								GUIManager.SetMusic (audio.clip.name);
						} catch (System.Exception e) {
								print (string.Format ("Caught MusicManager Exception: {0}", e.Message));
						}
				}

		}
}
