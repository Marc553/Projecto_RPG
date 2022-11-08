using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100; //numero de vida del player
    private int currentHealth; //numero de vida que se tiene al momento(mientras juegas)

    private void Start()
    {
        UpdateMaxHealth(maxHealth);//vida total que posee en el juego
    }

    public void DamageCharacter(int damage)//descuenta el numero de daño del enemigo a a vida del player
    {
        currentHealth -= damage; //resta el daño al numero actual de vida
        if (currentHealth <= 0)//si la vida baja por debajo de 0 "mueres"
        {
            gameObject.SetActive(false);//"morir"
        }
    }

    public void UpdateMaxHealth(int newMaxHealth)//nunero acutal de la vida total 
    {
        maxHealth = newMaxHealth;//iguala la vida total a la vida que se muestra
        currentHealth = maxHealth;//la vida que se mestra es la total 
    }
}

