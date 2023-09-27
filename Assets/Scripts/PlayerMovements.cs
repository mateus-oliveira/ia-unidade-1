using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour {
    private float moveX, moveY;
    private float moveSpeed = 10f;

    // private SpriteRenderer sprite;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start() {
        // sprite = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update() {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        if (moveX != 0 || moveY != 0) {
            float x = moveX * moveSpeed;
            float y = moveY * moveSpeed;
            rigidBody.velocity = new Vector2(x, y);
        }
    }
}
