using System;
using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts
{
	public class GameHUDController : MonoBehaviourBase
	{
		public ButtonHandler MenuButton;

		public void Start()
		{
			MenuButton.Click += OnMenuButtonClick;
		}

		void OnMenuButtonClick(object sender, EventArgs e)
		{
			Application.LoadLevel(SceneNames.Menu);
		}
	}
}
