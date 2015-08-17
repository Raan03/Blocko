using UnityEngine;

namespace Assets.Managers
{
	/// <summary>
	/// Handles our disclaimer text on start up
	/// </summary>
	public class TextManager : MonoBehaviour
	{
		public GUIText Disclaimer;

	    void Start()
	    {
	        Disclaimer.fontSize = Mathf.Min(Screen.height, Screen.width)/Disclaimer.fontSize;
	    }

	    void Update ()
		{
			if (Time.time > 5)
				Application.LoadLevel (1);
		}
	}
}