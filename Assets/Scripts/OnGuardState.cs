using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnGuardState : NPCState
{
    private bool playerIsInSight = false;

    public OnGuardState(NPC npc) : base(npc) { }

    public override void Enter() {
        Debug.Log("Entrou no estado OnGuard");
    }

    public override void Update()
    {
        if (playerIsInSight)
        {
            npc.ChangeState(npc.GetKillPlayerState());
        }
    }


    public override void Exit()
    {
        Debug.Log("Saiu do estado OnGuard");
    }
}

