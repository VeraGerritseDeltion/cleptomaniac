using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour{
    public bool wantedState;
    public bool looking;
    public float timer;
    public SecurityAI sai = new SecurityAI();


    void Update(){
        if(looking && timer < 0){
            looking = false;
            sai.bk = false;
        }
        else{
            timer -= Time.deltaTime;
            sai.bk = true;
        }
    }
}
