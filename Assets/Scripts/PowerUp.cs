using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PowerUpType {
    HEAL,
    POWER
}

public class PowerUp : MonoBehaviour
{
    private int healAmount = 20;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private PowerUpType powerUpType;
    [SerializeField] private Sprite sprite;

    void Start(){
        if (sprite != null)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
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
