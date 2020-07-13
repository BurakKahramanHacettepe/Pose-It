using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WarpSlow")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<SpeedControl>().Slow();
        }
        else if(other.gameObject.tag == "Levels")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControlScript>().Lose();

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "WarpSlow")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<SpeedControl>().Normal();
        }
    }
}
