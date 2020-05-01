using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoBehaviourInvoker : MonoBehaviour
{
	[Flags]
	public enum EventType
	{
		None = 0,
		Start = 1 << 0,
		Update = 1 << 1,
		FixedUpdate = 1 << 2,
		LateUpdate = 1 << 3,
		Enable = 1 << 4,
		Disable = 1 << 5,
		All = ~0,
	}

	public EventType eventType;

	public UnityEvent onEvent = new UnityEvent();

	// Start is called before the first frame update
	void Start()
	{
		var isStart = (EventType.Start & eventType) == EventType.Start || (EventType.All & eventType) == EventType.All;
		if (isStart)
		{
			onEvent.Invoke();
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
