using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecurityAI : MonoBehaviour {
    public Transform player;
    public Transform myTransform;
    public NavMeshAgent navigator;
    public List<GameObject> checkPoints = new List<GameObject>();
    public int currentCheckPoint;
    public RaycastHit rayHit;
    public string doorTag;
    public string carTag;
    public AIManager aim;
    public bool stationary;
    public Animator securityAnimator;
    public InteractManager im;
    public Transform lookDirection;
    public int fieldOfView;

    void Start(){

    }

    void Update() {
        if(Physics.Raycast(transform.position,transform.forward,out rayHit,2) && rayHit.collider.gameObject.tag == doorTag || Physics.Raycast(transform.position,transform.forward,out rayHit,2) && rayHit.collider.gameObject.tag == carTag) {
            rayHit.collider.GetComponent<Interactable>().Interacting();
        }
        else if(aim.wantedState == false) {
            if(stationary == false) {
                securityAnimator.SetBool("Walking",true);
                navigator.SetDestination(checkPoints[currentCheckPoint].transform.position);
                if(myTransform.position.z == checkPoints[currentCheckPoint].transform.position.z && myTransform.position.x == checkPoints[currentCheckPoint].transform.position.x) {
                    if(currentCheckPoint == checkPoints.Count - 1) {
                        currentCheckPoint = 0;
                    }
                    else {
                        currentCheckPoint++;
                    }
            }

            }
            else{
                if(Random.Range(1,100) == 2){
                    securityAnimator.SetBool("Tip That Hat",true);
                    securityAnimator.SetBool("Tip That Hat",false);
                }
            }
        }
        else{
            navigator.speed = 3.5f;
            securityAnimator.SetBool("Wanted",true);
            navigator.SetDestination(player.position);
        }
        if(Input.GetButtonDown("Fire1")){
            StealNoticeVoid();
        }
    }

    public void StealNoticeVoid(){
        lookDirection.LookAt(player);
        print(lookDirection);
        if(Physics.Raycast(lookDirection.transform.position, lookDirection.transform.forward, out rayHit,10) && rayHit.collider.tag == "Player" && lookDirection.transform.rotation.y <= (transform.rotation.y - 50) && lookDirection.transform.rotation.y <= (transform.rotation.y + 50)){
            print("jalla");
  
        }
        else {
            print("panda");
        }
        Debug.DrawRay(lookDirection.transform.position,lookDirection.transform.forward,Color.red, 10);
    }
}
