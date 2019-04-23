using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class master : MonoBehaviour
{
    public GameObject ship;
    public GameObject data_in;

    // Start is called before the first frame update
    void Start()
    {
        data_in = GameObject.Find("data_obj");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
