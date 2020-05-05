using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventBehavior
{
	[AddComponentMenu("Event Behavior/Event Invoker")]
	public class EventInvoker : MonoBehaviour
	{
		public UnityEvent onInvoke = new UnityEvent();

		public void Invoke()
		{
			onInvoke.Invoke();
		}
	}

}

