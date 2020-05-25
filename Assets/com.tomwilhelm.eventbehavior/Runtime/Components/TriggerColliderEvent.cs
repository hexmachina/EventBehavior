using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventBehavior
{
	[AddComponentMenu("Event Behavior/Trigger Collider Event")]
	public class TriggerColliderEvent : MonoBehaviour
	{
		public LayerMask layerMask = ~0;

		public bool includeCollisionWithTriggers = true;

		[Header("Collider Tag")]
		public bool checkTags = false;

		public bool inclusive = false;

		public List<string> tags = new List<string>();

		[Header("Events")]
		public UnityColliderEvent onTriggerEnter = new UnityColliderEvent();
		public UnityColliderEvent onTriggerStay = new UnityColliderEvent();
		public UnityColliderEvent onTriggerExit = new UnityColliderEvent();

		private void OnTriggerEnter(Collider other)
		{
			if (isActiveAndEnabled && ((layerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer))
			{
				if (!includeCollisionWithTriggers && other.isTrigger)
					return;

				if (checkTags)
				{
					if (CheckColliderTag(other))
					{
						onTriggerEnter.Invoke(other);

					}
				}
				else
				{
					onTriggerEnter.Invoke(other);

				}
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (isActiveAndEnabled && (layerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
			{
				if (!includeCollisionWithTriggers && other.isTrigger)
					return;


				if (checkTags)
				{
					if (CheckColliderTag(other))
					{
						onTriggerStay.Invoke(other);
					}
				}
				else
				{
					onTriggerStay.Invoke(other);
				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (isActiveAndEnabled && (layerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
			{
				if (!includeCollisionWithTriggers && other.isTrigger)
					return;

				if (checkTags)
				{
					if (CheckColliderTag(other))
					{
						onTriggerExit.Invoke(other);
					}
				}
				else
				{
					onTriggerExit.Invoke(other);
				}
			}
		}

		private bool CheckColliderTag(Collider collider)
		{
			if (inclusive)
			{
				if (tags.Contains(collider.tag))
				{
					return true;
				}
			}
			else
			{
				if (!tags.Contains(collider.tag))
				{
					return true;
				}
			}
			return false;
		}

		public void DebugLogCollision(Collider collider)
		{
			if (Debug.isDebugBuild)
			{
				Debug.Log(collider.name);
			}
		}

	}

}

