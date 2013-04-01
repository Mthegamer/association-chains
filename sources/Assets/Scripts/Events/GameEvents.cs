using Assets.Scripts.Common;

namespace Assets.Scripts.Events
{
	public class  GameEvents : MonoBehaviourBase
	{
		private static bool _isInitialized;

		public static GameEvent<GameEventArgs<int>> LevelSelected { get; private set; }
		public static GameEvent<GameEventArgs<Placeholder>> PlaceholderGotCorrectImage { get; private set; }
		public static GameEvent<GameEventArgs<Level>> LevelSolved { get; private set; } 

		static GameEvents()
		{
			Initalize();
		}

		private static void Initalize()
		{
			if (!_isInitialized)
			{
				LevelSelected = new GameEvent<GameEventArgs<int>>();
				PlaceholderGotCorrectImage = new GameEvent<GameEventArgs<Placeholder>>();
				LevelSolved = new GameEvent<GameEventArgs<Level>>();
				_isInitialized = true;
			}
		}
	}
}
