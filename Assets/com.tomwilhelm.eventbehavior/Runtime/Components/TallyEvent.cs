using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventBehavior
{
	[AddComponentMenu("Event Behavior/Tally Event")]
	public class TallyEvent : MonoBehaviour
	{
		public int startValue = 0;

		public int minValue = 0;
		public int maxValue = 5;

		private int _count;

		private bool _init;

		public UnityEvent onIncrement = new UnityEvent();
		public UnityEvent onDecrement = new UnityEvent();

		public UnityIntEvent onCountChanged = new UnityIntEvent();

		public UnityStringEvent onCounterStringChanged = new UnityStringEvent();

		public void SetCount(int value)
		{
			_init = true;

			if (value != _count)
			{
				_count = value;
				if (_count > maxValue)
				{
					_count = minValue;
				}
				if (_count < minValue)
				{
					_count = maxValue;
				}

				onCounterStringChanged.Invoke(_count.ToString());
				onCountChanged.Invoke(_count);
			}
		}

		public void SetCountNoCallback(int value)
		{
			_init = true;

			if (value != _count)
			{
				_count = value;
				if (_count > maxValue)
				{
					_count = minValue;
				}
				if (_count < minValue)
				{
					_count = maxValue;
				}
			}
			onCounterStringChanged.Invoke(_count.ToString());
		}

		public void Increment()
		{
			if (!_init)
			{
				_count = Mathf.Clamp(startValue, minValue, maxValue);
			}

			SetCount(_count + 1);
			onIncrement.Invoke();
		}

		public void Decrement()
		{
			if (!_init)
			{
				_count = Mathf.Clamp(startValue, minValue, maxValue);
			}

			SetCount(_count - 1);
			onDecrement.Invoke();
		}
	}

}

