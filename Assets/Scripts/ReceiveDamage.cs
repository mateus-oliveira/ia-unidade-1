using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveDamage : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            NPC npc = gameObject.transform.parent.GetComponent<NPC>();
            npc.AddToLife(other.gameObject.transform.parent.GetComponent<PlayerMovements>().GetDamageAmount() * -1);
        }
    }
}
