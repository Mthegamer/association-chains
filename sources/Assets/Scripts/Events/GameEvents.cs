using Assets.Scripts.Common;

namespace Assets.Scripts.Events
{
	public class  GameEvents : MonoBehaviourBase
	{
		private static bool _isInitialized;

		public static GameEvent<GameEventArgs<int>> LevelSelected { get; private set; } 

		static GameEvents()
		{
			Initalize();
		}

		private static void Initalize()
		{
			if (!_isInitialized)
			{
				LevelSelected = new GameEvent<GameEventArgs<int>>();
				_isInitialized = true;
			}
		}
	}
}
