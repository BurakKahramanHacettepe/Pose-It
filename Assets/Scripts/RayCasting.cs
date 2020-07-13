using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    public bool pass = false;

    // Start is called before the first frame update
    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.forward, out hit))
        {
            if (hit.distance <= 21.0f)
            {
                pass = false;

            }
            else
            {
                pass = true;
            }
        }
    }

    private void Update()
    {
        Vector3 forward = Vector3.forward * 21f;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (!GetComponent<DragObject>().isDragging)
        {
            if (pass)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.green;

            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;

            }
        }

    }
}
