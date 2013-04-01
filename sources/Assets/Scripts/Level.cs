using System.Linq;
using Assets.Scripts.Common;
using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts
{
	public class Level : MonoBehaviourBase
	{
		private Placeholder[] _placeholders;

		public int Number;

		public void Start()
		{
			_placeholders = GetComponentsInChildren<Placeholder>();
			GameEvents.PlaceholderGotCorrectImage.Subscribe(OnPlaceholderGotCorrectImage);
		}

		private void OnPlaceholderGotCorrectImage(GameEventArgs<Placeholder> gameEventArgs)
		{
			bool isSolved = _placeholders.All(p => p.HasCorrectImage);
			if (isSolved)
			{
				GameEvents.LevelSolved.Publish(new GameEventArgs<Level>(this));
				Debug.Log("Level solved.");
			}
		}
	}
}
