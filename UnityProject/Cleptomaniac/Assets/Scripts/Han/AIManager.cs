using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour{
    public bool wantedState;
    public bool looking;
    public float timer;
    public SecurityAI sai;

    void Start(){
        sai = new SecurityAI();
    }


    void Update(){
        if(looking && timer < 0){
            looking = false;
        }
        else if(timer > 0){
            timer -= Time.deltaTime;
        }
    }
}
