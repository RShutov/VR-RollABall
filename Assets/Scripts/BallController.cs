using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rigidBody;
    private Animator animator;
    public float commonForce;
    public float upForce;
    private int obstacleCount;
    private Vector3 direction;
    private Vector3 force;

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("collectible")) {
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle")) {
            obstacleCount++;
        } 
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle")) {
            obstacleCount--;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rigidBody.AddForce(new Vector3(
            commonForce * direction.x,
            upForce * direction.y,
            commonForce * direction.z));
    }

    void Update()
    {
        var hAxis = Input.GetAxis("Horizontal");
        var vAxis = Input.GetAxis("Vertical");
        var haveObstacles = obstacleCount > 0;
        var jump = Input.GetKeyDown(KeyCode.Space) && haveObstacles;
        var upAxis = jump ? 1f : 0f;
        if (jump) {
            animator.SetBool("Jump", true);
        }
        direction = new Vector3(vAxis, upAxis, 0);
    }
}
