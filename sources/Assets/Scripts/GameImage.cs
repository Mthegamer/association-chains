using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts
{
	public class GameImage : MonoBehaviourBase
	{
		private Vector2 _startPosition;

		public bool IsLocked;

		public void Start()
		{
			_startPosition = Transform.position;
		}

		public void OnEnable()
		{
			EasyTouch.On_Drag += OnDrag;
			EasyTouch.On_DragEnd += OnDragEnd;
		}

		public void OnDisable()
		{
			EasyTouch.On_Drag -= OnDrag;
			EasyTouch.On_DragEnd -= OnDragEnd;
		}

		private void OnDrag(Gesture gesture)
		{
			if (IsLocked)
				return;

			if (gesture.pickObject == gameObject)
			{
				Transform.position = gesture.position;
				Transform.SetZ(-0.02f);
			}
		}

		private void OnDragEnd(Gesture gesture)
		{
			if (IsLocked)
				return;

			if (gesture.pickObject == gameObject)
			{
				Transform.SetZ(-0.01f);
			}
		}

		public void MoveToStartPosition()
		{
			
			Transform.position = _startPosition;
		}
	}
}
