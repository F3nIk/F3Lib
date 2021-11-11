using System.Collections.Generic;
using UnityEngine;

namespace F3Lib.Events
{

	[CreateAssetMenu(menuName = "F3Lib/Events/Event", order = 0)]
	public class FEvent : ScriptableObject
	{
#if UNITY_EDITOR
		[Multiline(5)]
		public string description;
		public bool debug;
#endif
		private List<EventItemListener> _listeners = new List<EventItemListener>();

		public void Raise()
		{
			for (int i = _listeners.Count - 1; i >= 0; i--)
			{
				_listeners[i].OnEventRaise();
			}

			#if UNITY_EDITOR
			if(debug) Debug.Log(name + ": Raise()");
			#endif
		}

		public void Raise(int value)
		{
			for (int i = _listeners.Count - 1; i >= 0; i--)
			{
				_listeners[i].OnEventRaise(value);
			}

			#if UNITY_EDITOR
			if(debug) Debug.Log(name + $": Raise<int>({value})");
			#endif
		}

		public void Raise(float value)
		{
			for (int i = _listeners.Count - 1; i >= 0; i--)
			{
				_listeners[i].OnEventRaise(value);
			}

			#if UNITY_EDITOR
			if(debug) Debug.Log(name + $": Raise<float>({value})");
			#endif
		}

		public void Raise(string value)
		{
			for (int i = _listeners.Count - 1; i >= 0; i--)
			{
				_listeners[i].OnEventRaise(value);
			}

			#if UNITY_EDITOR
			if(debug) Debug.Log(name + $": Raise<string>({value})");
			#endif
		}

		public void Raise(bool value)
		{
			for (int i = _listeners.Count - 1; i >= 0; i--)
			{
				_listeners[i].OnEventRaise(value);
			}

			#if UNITY_EDITOR
			if(debug) Debug.Log(name + $": Raise<bool>({value})");
			#endif
		}

		public void Raise(Transform value)
		{
			for (int i = _listeners.Count - 1; i >= 0; i--)
			{
				_listeners[i].OnEventRaise(value);
			}

			#if UNITY_EDITOR
			if(debug) Debug.Log(name + $": Raise<Transform>({value})");
			#endif
		}

		public void Raise(Vector2 value)
		{
			for (int i = _listeners.Count - 1; i >= 0; i--)
			{
				_listeners[i].OnEventRaise(value);
			}

			#if UNITY_EDITOR
			if(debug) Debug.Log(name + $": Raise<Vector2>({value})");
			#endif
		}

		public void Raise(Vector3 value)
		{
			for (int i = _listeners.Count - 1; i >= 0; i--)
			{
				_listeners[i].OnEventRaise(value);
			}

			#if UNITY_EDITOR
			if(debug) Debug.Log(name + $": Raise<Vector3>({value})");
			#endif
		}

		public void RegisterListener(EventItemListener listener)
		{
			if (!_listeners.Contains(listener))
				_listeners.Add(listener);
		}

		public void UnregisterListener(EventItemListener listener)
		{
			if (_listeners.Contains(listener))
				_listeners.Remove(listener);
		}
	}

}