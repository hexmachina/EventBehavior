using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventBehavior
{

	public class EnableEvent : MonoBehaviour
	{
		public UnityEvent onEnabled = new UnityEvent();
		public UnityEvent onDisabled = new UnityEvent();

		private void OnEnable()
		{
			onEnabled.Invoke();
		}

		private void OnDisable()
		{
			onDisabled.Invoke();
		}
	}

}

