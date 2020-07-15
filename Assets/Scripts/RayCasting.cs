using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    public GameObject controller;

    public bool pass = false;

    public LayerMask layermask;
    // Start is called before the first frame update
    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        return Quaternion.Euler(angles) * (point - pivot) + pivot;
    }
    void OnDrawGizmosSelected()
    {
        Vector3 forward = Vector3.forward * 21f;

        Gizmos.DrawRay(RotatePointAroundPivot((transform.position + Vector3.down / 5f), transform.position, transform.rotation.eulerAngles), forward);
        Gizmos.DrawRay(RotatePointAroundPivot(transform.position , transform.position, transform.rotation.eulerAngles), forward);

        Gizmos.DrawRay(RotatePointAroundPivot((transform.position + Vector3.forward / 30f + Vector3.up / 5f), transform.position, transform.rotation.eulerAngles), forward);
        Gizmos.DrawRay(RotatePointAroundPivot((transform.position + Vector3.back / 30f + Vector3.up / 5f), transform.position, transform.rotation.eulerAngles), forward);
    }
    void FixedUpdate()
    {
        RaycastHit hit;
        RaycastHit hit1;
        RaycastHit hit2;
        RaycastHit hit3;

        if (Physics.Raycast(RotatePointAroundPivot((transform.position + Vector3.down / 5f), transform.position,transform.rotation.eulerAngles), Vector3.forward, out hit,25f, layermask)
            &&
            Physics.Raycast(RotatePointAroundPivot((transform.position), transform.position, transform.rotation.eulerAngles), Vector3.forward, out hit1,25f, layermask)
            &&
            Physics.Raycast(RotatePointAroundPivot((transform.position + Vector3.forward / 30f + Vector3.up / 5f), transform.position, transform.rotation.eulerAngles), Vector3.forward, out hit2, 25f, layermask)
            &&
            Physics.Raycast(RotatePointAroundPivot((transform.position + Vector3.back / 30f + Vector3.up / 5f), transform.position, transform.rotation.eulerAngles), Vector3.forward, out hit3, 25f, layermask)

            )
        {


            print(gameObject.name + ": " + (hit.distance + hit1.distance+ hit2.distance + hit3.distance));
            



            if (hit.distance + hit1.distance + hit2.distance + hit3.distance <= 85.0f)
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
        Debug.DrawRay(RotatePointAroundPivot((transform.position + Vector3.down / 12f), transform.position, transform.rotation.eulerAngles), forward, Color.green);
        Debug.DrawRay(RotatePointAroundPivot((transform.position + Vector3.up / 5f), transform.position, transform.rotation.eulerAngles), forward, Color.green);

        Debug.DrawRay(RotatePointAroundPivot((transform.position + Vector3.forward / 30f), transform.position, transform.rotation.eulerAngles), forward, Color.green);
        Debug.DrawRay(RotatePointAroundPivot((transform.position + Vector3.back / 30f), transform.position, transform.rotation.eulerAngles), forward, Color.green);


        if (!controller.GetComponent<DragObject>().isDragging)
        {
            if (pass)
            {
                controller.GetComponent<Renderer>().material.color = Color.green;

            }
            else
            {
                controller.GetComponent<Renderer>().material.color = Color.red;

            }
        }

    }
}
