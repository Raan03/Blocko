using System.Collections.Generic;
using UnityEngine;

namespace Assets.Managers
{
	/// <summary>
	/// Our Music Manager -- for handling Music Logic
	/// </summary>
	public class MusicManager : MonoBehaviour
	{
		static List<int> _played = new List<int> ();
		public List<AudioClip> MyMusic;

        void Start ()
		{
			PlayRandomMusic ();
		}

	    void DisplayMusic()
	    {
            try
            {
                GuiManager.SetMusic(GetComponent<AudioSource>().clip.name);
            }
            catch (System.Exception e)
            {
                print(string.Format("Caught MusicManager->PlayRandomMusic::SetMusic Exception: {0}", e.Message));
            }
        }
		void Update ()
		{
			if (!GetComponent<AudioSource>().isPlaying) {
				PlayRandomMusic ();
			}
		}

		void PlayRandomMusic ()
		{
            // make sure we have music available [...]
		    if (MyMusic.Count == 0)
		    {
		        return;
		    }

		    // if we played all available music, reset the list!
		    if (_played.Count == MyMusic.Count)
		        _played.Clear();

		    int rng = Random.Range (0, MyMusic.Count);

		    while (_played.Contains (rng)) {
		        // so we don't play music already played while others aren't heard of yet
		        rng = Random.Range (0, MyMusic.Count);
		    }

		    _played.Add (rng);

		    GetComponent<AudioSource>().clip = MyMusic [rng];
		    GetComponent<AudioSource>().Play ();

		    DisplayMusic();
		}
	}
}