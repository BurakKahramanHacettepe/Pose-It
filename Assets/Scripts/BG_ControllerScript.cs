using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_ControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bg1;
    public GameObject bg2;

    public GameObject Conveyer;

    private float lim_z = 80f;
    public void Swap(float z)
    {
        GameObject behind;
        if (z>lim_z)
        {
            if (bg1.transform.position.z > bg2.transform.position.z)
            {
                behind = bg2;
            }
            else
            {
                behind = bg1;
            }

            int x0 = Random.Range(-1.0f, 1.0f) > 0 ? 1 : -1;
            int z0 = Random.Range(-1.0f, 1.0f) > 0 ? 1 : -1;
            int x1 = Random.Range(-1.0f, 1.0f) > 0 ? 1 : -1;
            int z1 = Random.Range(-1.0f, 1.0f) > 0 ? 1 : -1;


            behind.transform.GetChild(0).transform.localScale = new Vector3(x0,1,z0);
            behind.transform.GetChild(1).transform.localScale = new Vector3(x1, 1, z1);

            behind.transform.position += 2 * new Vector3(0, 0, 80f);
            lim_z += 80f;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        Swap(-Conveyer.transform.position.z);   
    }
}
