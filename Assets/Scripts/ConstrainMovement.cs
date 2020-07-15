using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrainMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;

    bool isRight;
    float distance;
    Vector3 pos;

    float x_offset = 0.3f;

    void Start()
    {
        
        distance = Vector3.Distance(transform.position, target.transform.position);
        isRight = transform.position.x>0 ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        
        pos = (transform.position - target.transform.position).normalized * distance + target.transform.position;

        if (isRight)
        {
            pos.x = Mathf.Clamp(pos.x, x_offset +0.75f -distance,0.75f);
        }
        else
        {
            pos.x = Mathf.Clamp(pos.x,-0.75f  , -0.75f + distance - x_offset);
        }
        pos.z = 0;

        transform.position = pos;
    }
}
