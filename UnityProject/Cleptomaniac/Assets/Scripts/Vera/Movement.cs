﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movSpeed;
    public float mouseSen;
    public float horizontal;
    public float vertical;
    public float vert;
    public float movVert;
    public float movHor;
    public float upDownRange;
    public Camera cam;
    public Rigidbody player;
    public float jumpHight;
    public bool jumped;
    public float walkSpd;
    public float runSpd;
    public float endurance;
    public float enduranceLenght;
    public float enduranceDepletion;
    public bool outOfBreath;
    public float backInBreath; 

    void Update()
    {
        MovementChar();
        if (jumped == false){
            Jump();
        }
    }

    public void MovementChar()
    {
        if (Input.GetButton("Fire3") && endurance > 0 && outOfBreath == false)
        {
            movSpeed = runSpd;
            if(movVert != 0 || movHor != 0)
            {
                endurance -= enduranceDepletion;
            }
        }
        else
        {
            movSpeed = walkSpd;
            if (endurance < enduranceLenght)
            {
                endurance += enduranceDepletion;
            }
        }
        if(endurance == 0)
        {
            outOfBreath = true;
        }
        if(endurance >= backInBreath)
        {
            outOfBreath = false;
        }

        horizontal = Input.GetAxis("Mouse X") * mouseSen * Time.deltaTime;
        vertical = Input.GetAxis("Mouse Y") * mouseSen * Time.deltaTime;
        movVert = Input.GetAxis("Vertical") * movSpeed * Time.deltaTime;
        movHor = Input.GetAxis("Horizontal") * movSpeed * Time.deltaTime;
        transform.Translate(new Vector3(movHor, 0, movVert) );
        transform.Rotate(0, horizontal, 0);
        vert -= vertical;
        vert = Mathf.Clamp(vert, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(vert, 0, 0);
    }

    public void Jump()
    { 
        if (Input.GetButtonDown("Jump")){
            player.AddForce(transform.up * jumpHight);
            jumped = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Floor")
        {
            jumped = false;
        }
    }
}
