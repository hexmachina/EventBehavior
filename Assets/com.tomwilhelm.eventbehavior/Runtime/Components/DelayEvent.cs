using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventBehavior
{
	public class DelayEvent : MonoBehaviour
	{
		[SerializeField]
		private float _duration = 5f;

		public float duration { get { return _duration; } set { _duration = value; } }

		public bool playOnEnable = false;

		public bool resetOnInvoke = false;

		public bool resetOnDisable = false;

		public UnityEvent onDelayCompleted = new UnityEvent();

		private void OnEnable()
		{
			if (playOnEnable)
			{
				BeginDelay();
			}
		}

		private void OnDisable()
		{
			if (resetOnDisable)
			{
				StopAllCoroutines();
			}
		}

		public void BeginDelay()
		{
			if (resetOnInvoke)
			{
				StopAllCoroutines();
			}
			StartCoroutine(Delay());
		}

		private IEnumerator Delay()
		{
			yield return new WaitForSeconds(duration);

			onDelayCompleted.Invoke();
		}
	}

}

