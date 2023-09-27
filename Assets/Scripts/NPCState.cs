using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class NPCState: MonoBehaviour {
    protected NPC npc;

    public NPCState(NPC npc) {
        this.npc = npc;
    }

    public abstract void OnTriggerEnter2D(Collider2D other);
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
