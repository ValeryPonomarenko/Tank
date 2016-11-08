using Interfaces;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private const int DISTANCE = 100;

    public float Damage;
    //public float FireRate;
    public ParticleSystem ShootParticle;
    public AudioClip ShootSound;

    public void Shoot()
    {
        ShootParticle.Play();
        AudioSource.PlayClipAtPoint(ShootSound, transform.position);

        RaycastHit hit;
        if (Physics.Raycast(new Ray(transform.position, transform.forward), out hit, DISTANCE))
        {
            IDamageable target = hit.collider.GetComponent<IDamageable>();
            if (target != null)
                target.GetDamage(Damage);
        }
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}