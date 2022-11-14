using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponDamage : MonoBehaviour
{
    public int damage;
    public GameObject bloodParticle;
    private GameObject hitPoint;

    private void Start()
    {
        hitPoint = transform.Find("Hit Point").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
            if (bloodParticle != null && hitPoint != null)
            {
                Destroy(Instantiate(bloodParticle, hitPoint.transform.position,
                 hitPoint.transform.rotation), 1.5f);
            }
        }
    }
}