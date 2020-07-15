using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        gameObject.transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject,new Vector3(0.7f,0.7f,1f),0.5f);
        Invoke("Pingpong",4f);
    }

    // Update is called once per frame

    
    void Pingpong()
    {
        LeanTween.scale(gameObject, new Vector3(0.75f, 0.75f, 1f), 0.3f).setLoopPingPong(50);

    }
  



}
