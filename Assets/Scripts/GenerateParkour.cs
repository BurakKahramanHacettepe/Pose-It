using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateParkour : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] levels;

    public GameObject player;

    public float speed = 1.0f;

    float lim_z = 0f;
    void Parkour()
    {
        lim_z -= 10f;
        GameObject r = levels[Random.Range(0,levels.Length)];

        GameObject myNewLevel = Instantiate(r, new Vector3(transform.position.x, 0f, -lim_z), Quaternion.Euler(-90,0,0));
        myNewLevel.transform.parent = gameObject.transform;
    }

    private void Start()
    {
        Parkour();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, -6f*transform.position.z/10f));
        if (transform.position.z<lim_z)
        {
            Parkour();

        }

    }
}
