using Managers;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof (Rigidbody))]
    public class EnemyMovement : MonoBehaviour
    {
        public float Speed;

        private GameObject playerObject;
        private Rigidbody enemyRigidbody;

        private void Start()
        {
            playerObject = GameManager.GetInstance().GetPlayerObject();
            enemyRigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (playerObject.activeInHierarchy)
            {
                transform.LookAt(playerObject.transform);
                enemyRigidbody.MovePosition(transform.position + transform.forward*Speed*Time.deltaTime);
            }
        }
    }
}