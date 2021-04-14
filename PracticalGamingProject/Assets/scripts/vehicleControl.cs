using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicleControl : MonoBehaviour
{
    enum boost_state { charging, boosting };
    boost_state nitro_is = boost_state.charging;
    float current_speed = 15.0f;
    float turning_speed = 180.0f;
    float current_turning_direction = 0;
    float _nitro = 100f;
    float nitro_replenish_rate = 5;
    float nitro_use_rate = 10;
    float Nitro
    {
        get { return _nitro; }
        set { _nitro = Mathf.Clamp(value,0,100); }
    }
    public BoostBar boostBar;
    Transform wheel;
    cameraControl my_camera;
    
    // Start is called before the first frame update
    void Start()
    {
        my_camera = Camera.main.GetComponent<cameraControl>();
        wheel = transform.GetChild(0);

        my_camera.my_owner_is(transform);

        boostBar.SetMaxBoost((int)_nitro);
    }

    // Update is called once per frame
    void Update()
    {
        current_turning_direction = 0;
        if (should_turn_left()) turn_left();
        if (should_turn_right()) turn_right();

        if (should_move_forward()) move_forward();
        if (should_move_backward()) move_backward();

        if(nitro_is == boost_state.charging)
            Nitro += nitro_replenish_rate * Time.deltaTime;

        boostBar.SetBoost((int)_nitro);
    }

    private void turn_right()
    {
        current_turning_direction = 1.0f;
        // transform.Rotate(Vector3.up, turning_speed * Time.deltaTime);
    }

    private void turn_left()
    {
        current_turning_direction = -1.0f;
        //transform.Rotate(Vector3.up, -turning_speed * Time.deltaTime);
    }

    private void move_backward()
    {
        transform.Rotate(Vector3.up * turning_speed * current_turning_direction * Time.deltaTime);

        wheel.Rotate(Vector3.right * current_speed * 100 * Time.deltaTime);

        transform.position -= current_speed * transform.forward * Time.deltaTime;
    }

    /// <summary>
    /// Move the vehicle in a forward direation, relative to it's own orientation.
    /// </summary>
    private void move_forward()
    {
        if (Input.GetKey(KeyCode.Space)) { 
            if(nitro_is == boost_state.charging) {
                if (Nitro > 20)
                    nitro_is = boost_state.boosting; 
            }
            else
            {
                current_speed = current_speed * 2;

                Nitro -= nitro_use_rate * Time.deltaTime;

                if (Nitro == 0)
                    nitro_is = boost_state.charging;
            }

        }

        //boostBar.SetBoost((int)_nitro);

        transform.Rotate(Vector3.up * turning_speed * current_turning_direction * Time.deltaTime);

        wheel.Rotate(Vector3.right * current_speed * 100 * Time.deltaTime);

        transform.position += current_speed * transform.forward * Time.deltaTime;

        current_speed = 15.0f;
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