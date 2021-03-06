﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    float camera_distance = 8;
    float camera_height = 5;
    float focus_distance = 50;
    private Vector3 desired_position;
    private Quaternion desired_orienation;
    private Transform character;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 focus = character.position + focus_distance * character.forward;
        //transform.position = character.position - character.forward * camera_distance + Vector3.up * camera_height;
        //transform.LookAt(character.position + focus_distance * character.forward);

        desired_position = character.position - character.forward * camera_distance + Vector3.up * camera_height;
        Vector3 front_camera_to_focus = focus - transform.position;
        desired_orienation = Quaternion.LookRotation(front_camera_to_focus.normalized, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, desired_position, 0.1f);
        transform.rotation = Quaternion.Slerp(transform.rotation, desired_orienation, 0.05f);
    }

    internal void my_owner_is(Transform owner)
    {
        character = owner;
    }
}
