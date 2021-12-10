using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(Animator))]
//[RequireComponent(typeof(AudioSource))]
public class CarController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float maxSpeed = 20f;
    [SerializeField] float maxTurnSpeed = 150f;

    float moveAmountThisFrame = 0;
    float turnAmountThisFrame = 0;
    bool isMoving = false;
    bool isDead = false;

    Vector3 startingPos;

    //[Header("Feedback")]
    //[SerializeField] TrailRenderer trail = null;
    //[SerializeField] ParticleSystem deathParticles = null;
    //[SerializeField] AudioClip deathSFX = null;

    [Header("Required References")]
    //[SerializeField] GameObject artToDisableOnDeath = null;
    [SerializeField] Rigidbody rigidbodyComponent = null;

    //[Header("Respawn After Falling")]
    //[SerializeField] float respawnDepth = -10f;

    


    void Start()
    {
        // setup our car defaults


        startingPos = transform.position;
    }

    void Update()
    {
        // if player is dead, exit early
        if (isDead)
            return;

        CalculateMoveAmountThisFrame();
        CalculateTurnAmountThisFrame();


        

        //This a simple piece of code that would respawn the player to the starting position
        //if (transform.position.y < respawnDepth)
        //{
        //    transform.position = startingPos;
        //}

    }

    // physics
    private void FixedUpdate()
    {
        Move();
        // only turn if currently moving
        if (moveAmountThisFrame != 0)
        {
            Turn();
        }
    }

    void CalculateMoveAmountThisFrame()
    {
        moveAmountThisFrame = Input.GetAxis("Vertical") * maxSpeed;
    }

    void CalculateTurnAmountThisFrame()
    {
        turnAmountThisFrame = Input.GetAxis("Horizontal") * maxTurnSpeed;
    }

    void Move()
    {
        // move the car rigidbody, based on move calculation
        Vector3 newMovement = transform.forward * moveAmountThisFrame * Time.deltaTime;
        rigidbodyComponent.MovePosition(rigidbodyComponent.position + newMovement);
    }

    void Turn()
    {
        // turn the car rigidbody, based on turn calculation
        Quaternion newRotation = Quaternion.Euler(0, turnAmountThisFrame * Time.deltaTime, 0);
        rigidbodyComponent.MoveRotation(rigidbodyComponent.rotation * newRotation);
    }



    void HandleMaxSpeedTrail()
    {
        
    }

    public void Die()
    {
        
    }

    private void DisableDeathObjects()
    {
        
    }
}
