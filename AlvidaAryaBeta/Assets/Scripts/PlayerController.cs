using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Animator animator;

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

        Vector3 move = new Vector3(moveX, 0, moveZ);

        transform.Translate(move); // translate defaults to local space
        

        animator.SetBool("isMoving", moveX != 0 || moveZ != 0);
    }
}
