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

    public float diff_speed = 0.0f;

    float acc = 20f;

    bool slow = false;

  

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
        if (!GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControlScript>().lost)
        {
            currentSpeed += acc * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 2+ diff_speed, 10+ diff_speed);
            conveyor.GetComponent<GenerateParkour>().speed = currentSpeed;
        }
        
    }

    public void Slow()
    {
        slow = true;
        currentSpeed -= acc *5f* Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 2+ diff_speed, 10+ diff_speed);
        conveyor.GetComponent<GenerateParkour>().speed = currentSpeed;
    }

    public void Normal()
    {
        slow = false;
       
    }
}
