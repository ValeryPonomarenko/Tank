using UnityEngine;

namespace Character
{
    [RequireComponent(typeof (Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        public float MovementSpeed;
        public float TurnSpeed;

        private Rigidbody playerRigidbody;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            var motionVector = transform.forward*Input.GetAxis("Vertical")*MovementSpeed*Time.deltaTime;
            playerRigidbody.MovePosition(transform.position + motionVector);

            var turnAngle = TurnSpeed*Input.GetAxis("Horizontal")*TurnSpeed*Time.deltaTime;
            transform.Rotate(0f, turnAngle, 0f);
        }
    }
}