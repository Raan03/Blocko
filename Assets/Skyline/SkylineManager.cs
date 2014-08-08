using UnityEngine;
using System.Collections.Generic;
using MA = AssemblyCSharp.Managers;
using RU = AssemblyCSharp.Runner;

namespace AssemblyCSharp.Skyline
{
	/// <summary>
	/// This handles our dynamic generated double skyline
	/// </summary>
	public class SkylineManager : MonoBehaviour
	{
		public Transform prefab;
		public int numberOfObjects;
		public float recycleOffset;
		public Vector3 startPosition;

		private Vector3 _nextPosition;
		private Queue<Transform> _objectQueue;
		// Use this for initialization
		void Start ()
		{
			MA.GameEventManager.GameStart += GameStart;
			MA.GameEventManager.GameOver += GameOver;
			_objectQueue = new Queue<Transform> (numberOfObjects);
			for (int i = 0; i < numberOfObjects; i++) {
				_objectQueue.Enqueue ((Transform)Instantiate (
					prefab, new Vector3 (0f, 0f, -100f), Quaternion.identity));		
			}
			enabled = false;
		}

		void GameStart ()
		{
			_nextPosition = startPosition;
			for (int i = 0; i < numberOfObjects; i++) {
				Recycle ();
			}
			enabled = true;
		}

		void GameOver ()
		{
			enabled = false;
		}
		// Update is called once per frame
		void Update ()
		{
			if (_objectQueue.Peek ().localPosition.x + recycleOffset < RU.Runner.distanceTraveled) {
				Recycle ();
				
			}
		}

		public Vector3 minSize, maxSize;

		private void Recycle ()
		{
			Vector3 scale = new Vector3 (
				                   Random.Range (minSize.x, maxSize.x),
				                   Random.Range (minSize.y, maxSize.y),
				                   Random.Range (minSize.z, maxSize.z)
			                   );
			Vector3 position = _nextPosition;
			position.x += scale.x * 0.5f;
			position.y += scale.y * 0.5f;

			Transform o = _objectQueue.Dequeue ();
			o.localScale = scale;
			o.localPosition = position;
			_nextPosition.x += scale.x;
			_objectQueue.Enqueue (o);
		}
	}
}