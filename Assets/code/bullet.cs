using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    float x_bound;
    float y_bound;
    float z_bound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward);
        x_bound = Mathf.Abs(transform.position.x);
        y_bound = Mathf.Abs(transform.position.y);
        z_bound = Mathf.Abs(transform.position.z);
        if (x_bound > 20f | y_bound > 20f | z_bound > 20f)
        {
            Destroy(this.gameObject);
        }
    }
}
