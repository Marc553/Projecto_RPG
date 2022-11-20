using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100; //numero de vida del player
    private int currentHealth; //numero de vida que se tiene al momento(mientras juegas)
    public bool isBlinking;
    public float blinkingDuration;
    private float blinkingCounter;
    private SpriteRenderer _characterRenderer;
    private void Start()
    {
        UpdateMaxHealth(maxHealth);//vida total que posee en el juego
        _characterRenderer = GetComponent<SpriteRenderer>();
        UpdateMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (isBlinking)
        {
            blinkingCounter -= Time.deltaTime;
            if (blinkingCounter > blinkingDuration * 0.8)
            {
                ToggleColor(false);
            }
            else if (blinkingCounter > blinkingDuration * 0.6)
            {
                ToggleColor(true);
            }
            else if (blinkingCounter > blinkingDuration * 0.4)
            {
                ToggleColor(false);
            }
        }
        else if (blinkingCounter > blinkingDuration * 0.2)
        {
            ToggleColor(true);
        }
        else if (blinkingCounter > 0)
        {
            ToggleColor(false);
        }
        else
        {
            ToggleColor(true);
            isBlinking = false;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<PlayerController>().canMove = true;
        }
    }

    
    public void DamageCharacter(int damage)//descuenta el numero de daño del enemigo a a vida del player
    {

        currentHealth -= damage; //resta el daño al numero actual de vida
        if (currentHealth <= 0)//si la vida baja por debajo de 0 "mueres"
        {
            gameObject.SetActive(false);//"morir"
        }
        if (blinkingDuration > 0)
        {
            isBlinking = true;
            blinkingCounter = blinkingDuration;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<PlayerController>().canMove = false;
        }
    }

    public void UpdateMaxHealth(int newMaxHealth)//nunero acutal de la vida total 
    {
        maxHealth = newMaxHealth;//iguala la vida total a la vida que se muestra
        currentHealth = maxHealth;//la vida que se mestra es la total 
    }
    private void ToggleColor(bool isVisible)
    {
        Color color = _characterRenderer.color;
        color = new Color(color.r, color.g, color.b,
         isVisible ? 1 : 0);
        _characterRenderer.color = color;
    }
}

