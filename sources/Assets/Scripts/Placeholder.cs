using Assets.Scripts.Common;
using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts
{
	public class Placeholder : MonoBehaviourBase
	{
		private tk2dSprite _sprite;

		public GameImage CorrectGameImage;
		public GameImage CurrentGameImage;

		public bool HasCorrectImage { get { return CurrentGameImage == CorrectGameImage; } }

		public void Start()
		{
			_sprite = GetComponent<tk2dSprite>();
		}

		public void OnEnable()
		{
			EasyTouch.On_DragEnd += OnDragEnd;
			EasyTouch.On_Drag+=OnDrag;
		}

		public void OnDisable()
		{
			EasyTouch.On_DragEnd -= OnDragEnd;
			EasyTouch.On_Drag -= OnDrag;
		}


		private void OnDrag(Gesture gesture)
		{
			if (CurrentGameImage != null && CurrentGameImage.IsLocked)
				return;

			GameImage gameImage = gesture.pickObject.GetComponent<GameImage>();
			if (gameImage != null)
			{
				if (gameImage == CurrentGameImage)
					SetCurrentGameImage(null);

				Vector2 scale = new Vector2(0.5f, 0.5f);
				if (gameImage.collider.bounds.Intersects(collider.bounds))
					scale = new Vector2(0.55f, 0.55f);
				_sprite.scale = scale;
			}
		}

		private void OnDragEnd(Gesture gesture)
		{
			if (CurrentGameImage != null && CurrentGameImage.IsLocked)
				return;

			GameImage gameImage = gesture.pickObject.GetComponent<GameImage>();
			if (gameImage != null)
			{
				if (gameImage.collider.bounds.Intersects(collider.bounds))
				{
					if (CurrentGameImage == null)
					{
						gameImage.Transform.position = Transform.position;
						_sprite.scale = new Vector2(0.5f, 0.5f);
						SetCurrentGameImage(gameImage);
					}
				}
			}
		}

		private void SetCurrentGameImage(GameImage gameImage)
		{
			CurrentGameImage = gameImage;
			if (CurrentGameImage == CorrectGameImage)
			{
				Debug.Log("Get correct image.");
				GameEvents.PlaceholderGotCorrectImage.Publish(new GameEventArgs<Placeholder>(this));
			}
			else if (CurrentGameImage != null)
			{
				Debug.Log("Get incorrect image.");
			}
		}
	}
}
