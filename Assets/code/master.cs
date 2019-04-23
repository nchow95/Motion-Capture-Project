using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class master : MonoBehaviour
{
    public GameObject ship;
    public GameObject data_in_obj;
    public data data_in;

    // Start is called before the first frame update
    void Start()
    {
        data_in_obj = GameObject.Find("data_obj");
        data_in = data_in_obj.GetComponent<data>();
        if (data_in)
        {
            if (data_in.controller)
            {
                ship.AddComponent<measure>();
            }
            else if (data_in.keyboard)
            {
                ship.AddComponent<keyboard>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
