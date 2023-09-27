using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// No estado KillPlayer, o NPC persegue o jogador
public class KillPlayerState : NPCState
{
    public KillPlayerState(NPC npc) : base(npc) { }

    public override void Enter()
    {
        // Lógica de entrada para o estado KillPlayer
        Debug.Log("Entrou no estado KillPlayer");
    }

    public override void Update()
    {
        // Verifique se o jogador está à vista
        if (!PlayerIsInSight()) {
            npc.ChangeState(npc.GetOnGuardState());
        }
    }

    public override void Exit()
    {
        // Lógica de saída para o estado KillPlayer
        Debug.Log("Saiu do estado KillPlayer");
    }

    private bool PlayerIsInSight()
    {
        // Implemente a lógica para verificar se o jogador está visível ao NPC
        return false;
    }
}
