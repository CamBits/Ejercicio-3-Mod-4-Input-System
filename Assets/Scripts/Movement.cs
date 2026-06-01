using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //  Public Attributes
    public float movementspeed = 5;
    public float rotationspeed = 350;
    public Transform cameraTransform;

    public float dashDistance = 4;
    public float dashCoolddown = 2;

    // Private Attributes
    private float Dashtimer = 0;
 



   
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");

        float Vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Horizontal * Time.deltaTime * movementspeed);
        transform.Translate(Vector3.forward * Vertical * Time.deltaTime * movementspeed);


        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * rotationspeed);

        
        if (Input.GetKeyDown(KeyCode.Space) && Dashtimer <= 0)
        {

            Vector3 dashDirection;

            if (Horizontal != 0 || Vertical != 0)
            { 
            
                dashDirection = (transform.right * Horizontal + transform.forward * Vertical);

            }

            else
            {
                dashDirection = transform.forward;

            }
           

            transform.position += dashDirection * dashDistance;

            Dashtimer = dashCoolddown;

         

        }

        if (Dashtimer > 0)

        {
            Dashtimer -= Time.deltaTime;



        }
    }
}
