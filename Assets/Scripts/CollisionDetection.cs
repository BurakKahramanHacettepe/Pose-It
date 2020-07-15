using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WarpSlow")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<SpeedControl>().Slow();
        }
        else if(other.gameObject.tag == "Levels")
        {
            other.GetComponent<FadeOut>().toRed();
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
