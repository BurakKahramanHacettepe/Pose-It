using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject conveyor;

    public GameObject lhand;
    public GameObject rhand;

    float currentSpeed = 2f;
    float acc = 20f;

    bool slow = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lhand.GetComponent<RayCasting>().pass & rhand.GetComponent<RayCasting>().pass)
        {
            Warp();
        }
        if (slow)
        {
            Slow();
        }
    }

    private void Warp()
    {

        currentSpeed += acc * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 2, 10);
        conveyor.GetComponent<GenerateParkour>().speed = currentSpeed;
    }

    public void Slow()
    {
        slow = true;
        currentSpeed -= acc *5f* Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 2, 10);
        conveyor.GetComponent<GenerateParkour>().speed = currentSpeed;
    }

    public void Normal()
    {
        slow = false;
       
    }
}
