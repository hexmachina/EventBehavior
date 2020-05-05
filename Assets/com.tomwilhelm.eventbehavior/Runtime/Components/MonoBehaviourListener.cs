using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventBehavior
{
	[DisallowMultipleComponent]
	[AddComponentMenu("Event Behavior/MonoBehaviour Listener")]
	public class MonoBehaviourListener : MonoBehaviour
	{
		//[Flags]
		public enum MonoEventType
		{
			//None = 0,
			Start,// = 1 << 0,
			Update,// = 1 << 1,
			FixedUpdate,// = 1 << 2,
			LateUpdate,// = 1 << 3,
			Enable,//= 1 << 4,
			Disable,// = 1 << 5,
					//All //= ~0,
		}

		[Serializable]
		public class Entry
		{
			public MonoEventType eventID = MonoEventType.Start;
			public UnityEvent callback = new UnityEvent();

		}

		[SerializeField]
		private List<Entry> m_Delegates;

		public List<Entry> triggers
		{
			get
			{
				if (m_Delegates == null)
					m_Delegates = new List<Entry>();
				return m_Delegates;
			}
			set { m_Delegates = value; }
		}

		private void Execute(MonoEventType id)
		{
			for (int i = 0, imax = triggers.Count; i < imax; ++i)
			{
				var ent = triggers[i];
				if (ent.eventID == id && ent.callback != null)
					ent.callback.Invoke();
			}
		}

		private void OnEnable()
		{
			Execute(MonoEventType.Enable);
		}

		// Start is called before the first frame update
		void Start()
		{
			Execute(MonoEventType.Start);
		}

		// Update is called once per frame
		void Update()
		{
			Execute(MonoEventType.Update);
		}

		private void FixedUpdate()
		{
			Execute(MonoEventType.FixedUpdate);
		}

		private void LateUpdate()
		{
			Execute(MonoEventType.LateUpdate);
		}

		private void OnDisable()
		{
			Execute(MonoEventType.Disable);
		}

		public void DebugLog(string msg)
		{
			Debug.Log(msg);
		}

		public void DebugLogWarning(string msg)
		{
			Debug.LogWarning(msg);
		}

		public void DebugLogError(string msg)
		{
			Debug.LogError(msg);
		}
	}

}

