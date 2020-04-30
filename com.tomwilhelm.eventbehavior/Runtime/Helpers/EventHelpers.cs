using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace EventBehavior
{
	[Serializable]
	public class UnityIntEvent : UnityEvent<int> { }

	[Serializable]
	public class UnityFloatEvent : UnityEvent<float> { }

	[Serializable]
	public class UnityBoolEvent : UnityEvent<bool> { }

	[Serializable]
	public class UnityStringEvent : UnityEvent<string> { }

	[Serializable]
	public class UnityColorEvent : UnityEvent<Color> { }

	[Serializable]
	public class UnityTransformEvent : UnityEvent<Transform> { }

	[Serializable]
	public class UnityGameObjectEvent : UnityEvent<GameObject> { }

	[Serializable]
	public class UnityColliderEvent : UnityEvent<Collider> { }
}
