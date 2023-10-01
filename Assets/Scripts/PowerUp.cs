using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType {
    HEAL,
    POWER
}

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private PowerUpType powerUpType;
    private int healAmount = 30;
    private SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (powerUpType == PowerUpType.HEAL)
        {
            spriteRenderer.color = Color.red;
        } else {
            spriteRenderer.color = Color.blue;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovements playerScript = other.GetComponent<PlayerMovements>();
            if (powerUpType == PowerUpType.HEAL)
            {
                playerScript.AddToLife(healAmount);
            } else {
                playerScript.AddToBombs();
            }
            Destroy(gameObject);
        }
    }
}
