using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicleController : MonoBehaviour
{
    float current_speed = 15.0f;
    float turning_speed = 180.0f;
    cameraControl my_camera;
    // Start is called before the first frame update
    void Start()
    {
        my_camera = Camera.main.GetComponent<cameraControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (should_move_forward()) move_forward();
        if (should_move_backward()) move_backward();
        if (should_turn_left()) turn_left();
        if (should_turn_right()) turn_right();

        my_camera.my_Position_is(transform);
    }

    private void turn_right()
    {
        transform.Rotate(Vector3.up, turning_speed * Time.deltaTime);
    }

    private void turn_left()
    {
        transform.Rotate(Vector3.up, -turning_speed * Time.deltaTime);
    }

    private void move_backward()
    {
        transform.position -= current_speed * transform.forward * Time.deltaTime;
    }

    /// <summary>
    /// Move the vehicle in a forward direation, relative to it's own orientation.
    /// </summary>
    private void move_forward()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            current_speed = current_speed * 2;
        else
            current_speed = 15.0f;
        
        transform.position += current_speed * transform.forward * Time.deltaTime;
        //transform.Rotate(Vector3.right * current_speed * Time.deltaTime);
    }

    private bool should_turn_right()
    {
        return Input.GetKey(KeyCode.D);
    }

    private bool should_turn_left()
    {
        return Input.GetKey(KeyCode.A);
    }

    private bool should_move_backward()
    {
        return Input.GetKey(KeyCode.S);
    }

    private bool should_move_forward()
    {
        return Input.GetKey(KeyCode.W);
    }
}
