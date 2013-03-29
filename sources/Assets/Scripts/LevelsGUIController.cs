using System;
using Assets.Scripts.Common;
using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts
{
	public class LevelsGUIController : MonoBehaviourBase
	{
		public ButtonHandler MenuButton;

		public void Start()
		{
			MenuButton.Click += OnMenuButtonClick;
			GameEvents.LevelSelected.Subscribe(OnLevelSelected);
		}

		private void OnLevelSelected(GameEventArgs<int> gameEventArgs)
		{
			Debug.Log("Level selected:" + gameEventArgs.Value);
		}

		void OnMenuButtonClick(object sender, EventArgs e)
		{
			Application.LoadLevel(SceneNames.Menu);
		}

	}
}
