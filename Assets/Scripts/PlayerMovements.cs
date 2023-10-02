using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour {
    private float moveX, moveY;
    private float moveSpeed = 10f;
    private int maxLife = 100;
    private int life;
    private int bombAmounts = 0;
    private int damageAmount = 80;
    [SerializeField] private GameObject attack;

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
        this.Attack();
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

    public void AddToLife(int life) {
        this.life += life;
        if (this.life > maxLife) {
            this.life = maxLife;
        }
        if (this.life < 0) {
            this.life = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        UpdateUI();
    }

    public void AddToBombs(bool decrease=false){
        if (decrease) {
            bombAmounts--;
            if (bombAmounts < 0) {
                bombAmounts = 0;
            }
        } else {
            bombAmounts++;
        }

        UpdateUI();
    }

    private void UpdateUI(){
        lifeSlider.value = life;
        bombTexts.text = bombAmounts.ToString();
    }

    private void Attack () {
        if (bombAmounts <= 0){
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            attack.SetActive(true);
            this.AddToBombs(true);
            Invoke("EndAttack", 0.2f);
        }

        
    }

    private void EndAttack () {
        attack.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack"))
        {
            AddToLife(other.gameObject.transform.parent.GetComponent<NPC>().GetDamageAmount() * -1);
        }
    }

    public int GetDamageAmount(){
        return damageAmount;
    }
}
