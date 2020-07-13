using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bg1;
    public GameObject bg2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(bg1.transform.position);
    }
}
