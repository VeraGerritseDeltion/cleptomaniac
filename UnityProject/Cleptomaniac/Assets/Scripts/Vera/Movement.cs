using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movSpeed;
    public float mouseSen;
    public float horizontal;
    public float vertical;
    public float movVert;
    public float movHor;

    void Update()
    {
        MovementChar();
    }

    public void MovementChar()
    {
        horizontal = Input.GetAxis("Mouse X") * mouseSen * Time.deltaTime;
        vertical = Input.GetAxis("Mouse Y") * mouseSen * Time.deltaTime;
        movVert = Input.GetAxis("Vertical") * movSpeed * Time.deltaTime;
        movHor = Input.GetAxis("Horizontal") * movSpeed * Time.deltaTime;

        transform.Translate(new Vector3(movVert, 0, movHor) );

        transform.Rotate(0, horizontal, 0);
    }
}
