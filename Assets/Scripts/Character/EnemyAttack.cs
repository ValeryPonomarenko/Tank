using UnityEngine;
using Interfaces;
using Managers;

namespace Character
{
	public class EnemyAttack : MonoBehaviour
	{
		public float Damage;

		private void OnTriggerEnter(Collider triggeredCollider)
		{
			if (triggeredCollider.tag.Equals ("Player")) 
			{
				IDamageable target = triggeredCollider.gameObject.GetComponent<IDamageable> ();
				if (target != null) 
				{
					target.GetDamage (Damage);
					GameManager.GetInstance ().Dead (gameObject);
				}
			}
		}
	}
}