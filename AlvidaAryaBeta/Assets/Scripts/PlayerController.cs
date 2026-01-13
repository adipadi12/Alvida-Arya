using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private FloatingJoystick joystick; // reference to the floating joystick

    void Awake() // this safety check ensures animator is assigned
    {
        if(!animator)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // time.deltaTime makes movement frame rate independent
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveJoystickX = joystick.Horizontal * moveSpeed * Time.deltaTime;
        float moveJoystickZ = joystick.Vertical * moveSpeed * Time.deltaTime;

        Vector3 move = new Vector3(moveX, 0, moveZ).normalized; // normalize to prevent faster diagonal movement
        Vector3 moveJoystick = new Vector3(moveJoystickX, 0, moveJoystickZ).normalized;

        if(move.magnitude > 0.1f)
        {
            transform.Translate(move * moveSpeed * Time.deltaTime, Space.World); // translate defaults to world space

            Quaternion targetRotation = Quaternion.LookRotation(move);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // smooth rotation

        }

        if(moveJoystick.magnitude > 0.1f)
        {
            transform.Translate(moveJoystick * moveSpeed * Time.deltaTime, Space.World); // translate defaults to world space

            Quaternion targetRotation = Quaternion.LookRotation(moveJoystick);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // smooth rotation

        }

        animator.SetBool("isMoving", move.magnitude > 0.1f || moveJoystick.magnitude > 0.1f); // set animation parameter based on movement
    }
}
