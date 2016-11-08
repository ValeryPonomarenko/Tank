using UnityEngine;

namespace Character
{
	[RequireComponent(typeof (Rigidbody))]
	public class PlayerMovement: MonoBehaviour
	{
		public float MovementSpeed;
		public float TurnSpeed;

		private Rigidbody rigidbody;

		private void Awake()
		{
			rigidbody = GetComponent<Rigidbody> ();
		}

		private void Update()
		{
			var motionVector = transform.forward * Input.GetAxis ("Vertical") * MovementSpeed * Time.deltaTime;
			rigidbody.MovePosition(transform.position + motionVector);

			var turnAngel = TurnSpeed * Input.GetAxis ("Horizontal") * TurnSpeed * Time.deltaTime;
			transform.Rotate(0f, turnAngel, 0f);
		}
	}
}