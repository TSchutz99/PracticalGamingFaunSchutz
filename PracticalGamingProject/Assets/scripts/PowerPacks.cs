using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPacks : MonoBehaviour
{
    private float rotation_speed = 180f;
    private float height, startingHeight;
    private float freq = 2, range = 0.5f, t;
    internal Rigidbody rb;
    internal Manager theManager;

    // Start is called before the first frame update
    internal void Start()
    {
        startingHeight = transform.position.y;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    internal void Update()
    {
        transform.Rotate(Vector3.up, rotation_speed * Time.deltaTime, Space.World);

        height = startingHeight + range * Mathf.Sin(freq * t);

        t += Time.deltaTime;

        transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }

    internal void Iam(Manager manager)
    {
        theManager = manager;
    }
}
