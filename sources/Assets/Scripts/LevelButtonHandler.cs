using System;
using Assets.Scripts.Common;
using Assets.Scripts.Events;

namespace Assets.Scripts
{
	public class LevelButtonHandler : ButtonHandler
	{
		public int Number;

		public LevelButtonHandler()
		{
			Click += LevelButtonHandler_Click;
		}

		void LevelButtonHandler_Click(object sender, EventArgs e)
		{
			GameEvents.LevelSelected.Publish(new GameEventArgs<int>(Number));
		}
	}
}
