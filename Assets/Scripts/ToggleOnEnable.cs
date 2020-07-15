using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleOnEnable : MonoBehaviour
{
    // Start is called before the first frame update
    AudioListener listener;
    void OnEnable()
    {
        listener = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>();
        GetComponent<Toggle>().isOn = listener.enabled;
    }

    // Update is called once per frame
    
}
