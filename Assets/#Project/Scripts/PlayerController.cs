using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    Vector2 moveVector;
    float verticalSpeed;

    public float movementSpeed;
    public float gravityMultiplier;
    public float jumpSpeed;

    public CharacterController controller;

    public void ShootDadidouu(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("PAN!");

        }
        else if (context.canceled)
        {
            Debug.Log("*bruit de balle qui tombe*");
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && controller.isGrounded)
        {

        verticalSpeed += jumpSpeed;


        }

    }

    public void Move(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
        //Debug.Log(moveVector);
    }

    void Update()
    {
        
        if (controller.isGrounded && verticalSpeed < 0)
        {

                verticalSpeed = 0;

        }

            verticalSpeed += -9.81f * Time.deltaTime * gravityMultiplier;
        

        Vector3 movement = new Vector3(moveVector.x, 0, moveVector.y) * movementSpeed;

        if (movement != Vector3.zero)
        {

        transform.forward = Vector3.Lerp(transform.forward, movement, 0.1f);
        }


        movement.y = verticalSpeed;
        controller.Move(movement * Time.deltaTime);
    }


}
