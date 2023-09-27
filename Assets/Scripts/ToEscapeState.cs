using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// No estado ToEscape, o NPC foge se estiver com pouca vida
public class ToEscapeState : NPCState
{
    public ToEscapeState(NPC npc) : base(npc) { }

    public override void Enter()
    {
        // Lógica de entrada para o estado ToEscape
        Debug.Log("Entrou no estado ToEscape");
    }

    public override void Update()
    {
        // Verifique a saúde do NPC
        if (npc.GetLife() > 30) // Exemplo: Fuga apenas quando a vida estiver abaixo de 30
        {
            // Transição para OnGuard
            npc.ChangeState(npc.GetOnGuardState());
        }

        // Implemente a lógica para fugir do jogador
        // Isso pode envolver movimento para longe do jogador.
    }

    public override void Exit()
    {
        // Lógica de saída para o estado ToEscape
        Debug.Log("Saiu do estado ToEscape");
    }
}
