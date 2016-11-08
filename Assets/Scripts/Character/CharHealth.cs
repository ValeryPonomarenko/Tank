using Interfaces;
using Managers;
using UnityEngine;

namespace Character
{
    public class CharHealth : MonoBehaviour, IDamageable
    {
        public float Health;
        public float Shield;

        #region IDamageable

        public void GetDamage(float damage)
        {
            Health -= damage*Shield;

            if (Health <= 0)
            {
                GameManager.GetInstance().Dead(gameObject);
            }
        }

        #endregion

        public float GetHealth()
        {
            return Health;
        }
    }
}