using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PedestrianAI : MonoBehaviour {
    public Transform player;
    public Transform myTransform;
    public NavMeshAgent navigator;
    public List<GameObject> checkPoints = new List<GameObject>();
    public int currentCheckPoint;
    public RaycastHit rayHit;
    public RaycastHit rayHit2;
    public string doorTag;
    public string carTag;
    public string playerTag;
    public AIManager aim;
    public bool stationary;
    public Animator pedestrionAnimator;
    public InteractManager im;
    public int angleOfSight;
    public Transform lookDirection;
    public bool stopWalking;
    public float timer;
    public int stilStandingTime;

    void Start(){
        pedestrionAnimator.SetBool("Walking",true);
    }

    void Update() {
        if(Physics.Raycast(transform.position,transform.forward,out rayHit,2) && rayHit.collider.gameObject.tag == doorTag || Physics.Raycast(transform.position,transform.forward,out rayHit,2) && rayHit.collider.gameObject.tag == carTag){
            if(rayHit.collider.gameObject.tag == doorTag) {
                rayHit.collider.GetComponent<Interactable>().Interacting();
            }
        }
        navigator.SetDestination(checkPoints[currentCheckPoint].transform.position);
        if(myTransform.position.z == checkPoints[currentCheckPoint].transform.position.z && myTransform.position.x == checkPoints[currentCheckPoint].transform.position.x && stopWalking == false) {
            if(currentCheckPoint == checkPoints.Count - 1){
                pedestrionAnimator.SetBool("Walking",false);
                stopWalking = true;
                timer = stilStandingTime;
            }
            else {
                pedestrionAnimator.SetBool("Walking",true);
                currentCheckPoint++;
            }
        }
        else if(stopWalking == true && timer <= 0) {
            stopWalking = false;
            currentCheckPoint = 0;
        }
        else if(stopWalking == true) {
            timer -= Time.deltaTime;
        }
    }

    public void StealNoticeVoid() {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 toPlayer = player.position - transform.position;
        if(Vector3.Dot(forward,toPlayer) > 0) {
            Vector3 targetDir = player.transform.position - transform.position;
            float angle = Vector3.Angle(targetDir,transform.forward);
            if(angle < angleOfSight) {
                lookDirection.LookAt(player);
                if(Physics.Raycast(transform.position,lookDirection.forward,out rayHit2,8) && rayHit2.collider.tag == "Player") {
                    aim.wantedState = true;
                }
            }
        }
    }
}