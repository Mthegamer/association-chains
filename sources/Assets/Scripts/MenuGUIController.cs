using System;
using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts
{
	public class MenuGUIController : MonoBehaviourBase
	{

		public ButtonHandler PlayButton;

		public void Start () 
		{
			PlayButton.Click += OnPlayClick;
		}

		void OnPlayClick(object sender, EventArgs e)
		{
			Application.LoadLevel(SceneNames.Levels);
		}
	
	}
}
