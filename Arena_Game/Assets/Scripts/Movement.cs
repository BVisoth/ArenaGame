using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private float origionalStepOffset;
    public float jumpSpeed;

    public CharacterController characterController;
    private float ySpeed;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        origionalStepOffset = characterController.stepOffset;
    }
    void Update()
    {
        Vector3 deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        float magnitude = Mathf.Clamp01(deltaMove.magnitude) * speed;

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            characterController.stepOffset = origionalStepOffset;
            ySpeed = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }

        Vector3 velocity = deltaMove * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (deltaMove != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(deltaMove, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        }
    }
}
