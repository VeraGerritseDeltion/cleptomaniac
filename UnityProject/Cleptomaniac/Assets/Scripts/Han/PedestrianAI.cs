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
    public string doorTag;
    public string carTag;
    public AIManager aim;
    public Animator Pedestrian;

    void Update() {
        if(Physics.Raycast(transform.position,transform.forward,out rayHit,2) && rayHit.collider.gameObject.tag == doorTag || rayHit.collider.gameObject.tag == carTag) {
            if(rayHit.collider.gameObject.tag == doorTag) {
                rayHit.collider.GetComponent<Interactable>().Interacting();
            }
        }
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
}