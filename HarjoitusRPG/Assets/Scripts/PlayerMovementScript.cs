using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Move player and rotate the camera to look around
/// </summary>

public class PlayerMovementScript : MonoBehaviour
{
    [Tooltip("How fast does the character walk")]
    public float MovementSpeed = 10.0f;

    public float RotationSpeed = 10.0f;

    public GameObject FirstPersonCamera;

    public delegate void Attacked();
    public static event Attacked OnAttack;
       
    void Update()
    {
        float moveForward = Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;
        float moveRight = Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime;

        float rotateHorizontal = RotationSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        float rotateVertical = RotationSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;

        float x = FirstPersonCamera.transform.eulerAngles.x;
        float y = FirstPersonCamera.transform.eulerAngles.y;
        float z = FirstPersonCamera.transform.eulerAngles.z;
        Vector3 desiredRot = new Vector3(x + rotateVertical, y , z);

        //Move the player
        transform.Translate(0, 0, moveForward);
        transform.Translate(moveRight, 0, 0);

        //Rotate camera
        //Check if we are looking up or down using the 180. If we look down, the angle is less than 180 and if we look up the angle is more than 180
        //(the same as 60 vs -60 but it didn't want to work that way)
        if(desiredRot.x > 60 && desiredRot.x < 180)
        {
            desiredRot = new Vector3(60, y, z);
        }
        else if(desiredRot.x < 300 && desiredRot.x > 180)
        {
            desiredRot = new Vector3(300, y, z);
        }

        FirstPersonCamera.transform.rotation = Quaternion.Euler(desiredRot);

        //Rotate player (only horizontaly because we don't want the player character to fall over)
        transform.Rotate(0, rotateHorizontal, 0);

        Attack();
    }

    public void Attack()
    {
        if (Input.GetButton("Attack"))
        {
            Debug.Log("Attacked");
            //If player has a weapon equipped, Attack
            OnAttack?.Invoke();   
        }
    }
}
