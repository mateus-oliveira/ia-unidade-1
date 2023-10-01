using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovements : MonoBehaviour {
    private float moveX, moveY;
    private float moveSpeed = 10f;
    private int maxLife = 100;
    private int life;
    private int bombAmounts = 3; // Bomb é a coisinha q vai explodir em volta do jogador

    // UI
    [SerializeField] private Text bombTexts; 
    [SerializeField] private Slider lifeSlider;

    // private SpriteRenderer sprite;
    private Rigidbody2D rigidBody;

    void Start() {
        life = maxLife;
        // sprite = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        UpdateUI();
    }

    void Update() {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        if (moveX != 0 || moveY != 0) {
            float x = moveX * moveSpeed;
            float y = moveY * moveSpeed;
            rigidBody.velocity = new Vector2(x, y);
        } else {
            rigidBody.velocity = Vector2.zero;
        }
    }

    public void AddToLife(int life){ // "Adicionar" valor negativo no caso de tirar vida
        this.life += life;
        if (this.life > maxLife)
        {
            this.life = maxLife;
        }
        UpdateUI();
    }

    public void AddToBombs(){
        bombAmounts++;
        UpdateUI();
    }

    private void UpdateUI(){
        lifeSlider.value = life;
        bombTexts.text = "Bombas " + bombAmounts.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack"))
        {
            AddToLife(other.gameObject.transform.parent.GetComponent<NPC>().GetDamageAmount() * -1); // Dano do inimigo
        }
    }
}
