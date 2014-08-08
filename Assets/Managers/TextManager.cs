using UnityEngine;

/// <summary>
/// Handles our disclaimer text on start up
/// </summary>
public class TextManager : MonoBehaviour
{
		public GUIText disclaimer;
		void Update ()
		{
				if (Time.time > 5)
						Application.LoadLevel (1);
		}
}
