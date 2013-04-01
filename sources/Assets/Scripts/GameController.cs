using System.Linq;
using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts
{
	public class GameController : MonoBehaviourBase
	{
		public static int SelectedLevelNumber { get; set; }

		public GameObject LevelsHoster;

		public GameController()
		{
			//SelectedLevelNumber = 4;
		}

		public void Start()
		{
			Level[] levels = LevelsHoster.GetComponentsInChildren<Level>(true);
			Debug.Log(levels.Length);
			Level selectedLevel = levels.Single(l => l.Number == SelectedLevelNumber);
			selectedLevel.gameObject.SetActive(true);
		}
	}
}
