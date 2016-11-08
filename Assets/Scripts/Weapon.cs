using UnityEngine;
using Interfaces;

public class Weapon : MonoBehaviour
{
	public float Damage;
	public float FireRate;

	public void Shoot()
	{
		RaycastHit hit;
		if (Physics.Raycast (new Ray(transform.position, transform.forward), out hit, 100)) 
		{
			IDamageable targer = hit.collider.GetComponent<IDamageable> ();
			if (targer != null)
				targer.GetDamage (Damage);
		}
	}

	public void Activate()
	{
		gameObject.SetActive (true);
	}

	public void Deactivate()
	{
		gameObject.SetActive (false);
	}
}