using UnityEngine;

namespace Character
{
    public class WeaponAttack : MonoBehaviour
    {
        public Weapon[] Weapons;

        private Weapon currentWeapon;
        private int currentWeaponIndex;

        private void Awake()
        {
            currentWeaponIndex = 0;
            ChangeWeapon();
        }

        private void Update()
        {
            if (Input.GetButtonDown("ChangeWeaponLeft") || Input.GetButtonDown("ChangeWeaponRight"))
            {
                ChangeWeapon(Input.GetButtonDown("ChangeWeaponLeft") ? -1 : 1);
            }

            if (Input.GetButtonDown("Shoot"))
            {
                currentWeapon.Shoot();
            }
        }

        /// <summary>
        /// Меняет текущие оружие
        /// </summary>
        /// <param name="changeTo">
        /// -1, если надо изменить на оружие, которое левее текущего;
        /// 1, если надо изменить на оружие, которое правее текущего
        /// 0, чтобы активировать оружие (текущее оружие)
        /// </param>
        private void ChangeWeapon(int changeTo = 0)
        {
            if (currentWeapon != null)
                currentWeapon.Deactivate();

            changeTo = Mathf.Clamp(changeTo, -1, 1);
            currentWeaponIndex += changeTo;

            if (currentWeaponIndex < 0)
                currentWeaponIndex = Weapons.Length - 1;
            else if (currentWeaponIndex >= Weapons.Length)
                currentWeaponIndex = 0;

            currentWeapon = Weapons[currentWeaponIndex];

            currentWeapon.Activate();
        }
    }
}