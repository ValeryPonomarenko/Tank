using UnityEngine;
using Managers;

namespace Character
{
	[RequireComponent(typeof(Rigidbody))]
	public class EnemyMovement : MonoBehaviour 
	{
		public float Speed;

		private GameObject playerObject;
		private Rigidbody rigidbody;

		void Start () 
		{
			playerObject = GameManager.GetInstance ().GetPlayerObject ();
			rigidbody = GetComponent<Rigidbody> ();
		}

		private void Update()
		{
			transform.LookAt (playerObject.transform);
			rigidbody.MovePosition(transform.position + transform.forward * Speed * Time.deltaTime);
		}
	}
}