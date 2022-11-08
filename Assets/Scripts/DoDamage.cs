using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public float timeToRevivePlayer = 2;//tiempo para revivir

    public int damage = 10;//daño del enemigo
    /*
    private float timeRevivalCounter; //tiempo que pasa hasta reivir
    private bool isPlayerReviving;// mira si esta muerto o vivo el player
    private GameObject player; //player
    */
    
    private void Update()
    { /*
        if (isPlayerReviving)//mira si el player esta reviviendo 
        {
            timeRevivalCounter -= Time.deltaTime;//tiempo que pasa antes de revivir
            if (timeRevivalCounter <= 0)//si llega a 0 revivo
            {
                isPlayerReviving = false;//hace que sea falso el estar reviviendo
                player.SetActive(true);//revive al player
            }
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D other)//funcion que quita vida al player
    {
        if (other.gameObject.name.Equals("Player"))//si chocamos con el player quita "damage" vida
        {
            /*player = other.gameObject;
            player.SetActive(false);
            isPlayerReviving = true;
            timeRevivalCounter = timeToRevivePlayer;*/
            other.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);//entra en lo que choca, coge su componente vida y con la de quitar vida quita "damage" vida

        }
    }
}
