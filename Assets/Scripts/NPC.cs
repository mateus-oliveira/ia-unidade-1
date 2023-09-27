using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
    private int life = 100;
    private NPCState currentState;
    private OnGuardState onGuardState;
    private KillPlayerState killPlayerState;
    private ToEscapeState toEscapeState;

    private void Start() {
        onGuardState = new OnGuardState(this);
        killPlayerState = new KillPlayerState(this);
        toEscapeState = new ToEscapeState(this);

        currentState = onGuardState;
        currentState.Enter();
    }

    private void Update() {
        currentState.Update();
    }

    public void ChangeState(NPCState newState) {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }


    // Getters and Setters
    public OnGuardState GetOnGuardState(){
        return this.onGuardState;
    }
    public KillPlayerState GetKillPlayerState(){
        return this.killPlayerState;
    }
    public ToEscapeState GetToEscapeState(){
        return this.toEscapeState;
    }


    public int GetLife(){
        return this.life;
    }
    public void SetLife(int life){
        if (life > 100){
            this.life = 100;
        } else if (life < 0) {
            this.life = 0;
        } else {
            this.life = life;
        }
    }
}