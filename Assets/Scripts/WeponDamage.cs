using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponDamage : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
        }
    }
}
