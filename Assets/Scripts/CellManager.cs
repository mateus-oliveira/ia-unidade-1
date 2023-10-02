using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CellManager : MonoBehaviour {
    private GameObject player;
    private GameObject[,] cells = new GameObject[3, 3];
    [SerializeField] private float activationDistance = 20f;

    private void Start() {
        player = GameObject.Find("Player");

        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                GameObject cellGameObject = GameObject.Find("Cell" + i + j);
                cells[i, j] = cellGameObject;
            }
        }
    }

    private void Update() {
        // TODO adiconar verificação do move
        ActivateAdjacentCells();
    }

    private void ActivateAdjacentCells() {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                GameObject cell = cells[i, j];
                float distance = Vector3.Distance(player.transform.position, cell.transform.position);

                if (distance <= activationDistance) {
                    cell.SetActive(true);
                }
                else {
                    cell.SetActive(false);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack"))
        {
            other.gameObject.transform.parent.transform.parent = gameObject.transform;
        }
    }
}
