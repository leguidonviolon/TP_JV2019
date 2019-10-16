﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private new Camera camera;
    private GameObject throwingTransform;
    private Prediction linePrediction;
    private Volleyball ball;

    [SerializeField]
    private float speed;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        camera = GetComponentInChildren<Camera>();
        throwingTransform = GameObject.Find("ThrowingTransform");
        ball = throwingTransform.GetComponentInChildren<Volleyball>();
        linePrediction = throwingTransform.GetComponent<Prediction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            linePrediction.Show();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("test");
            ball.ThrowAction(linePrediction.vitesse_lancer);
        }

    }

    void FixedUpdate()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementZ = Input.GetAxis("Vertical");
        Vector3 horizontalMovement = camera.transform.right * movementX;
        Vector3 verticalMovement = new Vector3(camera.transform.forward.x, 0, camera.transform.forward.z) * movementZ;

        Vector3 velocity = Vector3.Normalize(horizontalMovement + verticalMovement) * speed;
        Move(velocity);
    }

    private void Move(Vector3 _velocity)
    {
        rigidbody.MovePosition(rigidbody.position + _velocity * Time.deltaTime);
    }
}
