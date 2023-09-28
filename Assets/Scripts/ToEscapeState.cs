using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// No estado ToEscape, o NPC foge se estiver com pouca vida
public class ToEscapeState : NPCState
{
    private bool isEscaping;
    public ToEscapeState(NPC npc) : base(npc) { }

    public override void Enter()
    {
        isEscaping = true;
        Debug.Log("Entrou no estado ToEscape");
    }

    public override void Update()
    {
        if (!isEscaping)
        {
            npc.ChangeState(npc.GetOnGuardState());
        }
    }

    public override void Exit()
    {
        Debug.Log("Saiu do estado ToEscape");
    }

    // TODO
    public override void HandleCollision(Collider2D other) {
        Debug.Log("Colidindo");
    }

    public override void CollisionFinished(Collider2D other) {
        isEscaping = false;
    }
}
