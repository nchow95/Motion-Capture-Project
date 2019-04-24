using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard : MonoBehaviour
{
    public GameObject bullet_obj;
    // Start is called before the first frame update
    void Start()
    {
        bullet_obj = GameObject.Find("ammunition");
    }

    // Update is called once per frame
    void Update()
    {
        
        float x_bound = this.transform.position.x;
        float y_bound = this.transform.position.y;
        float z_bound = this.transform.position.z;

        float horz_in = Input.GetAxisRaw("Horizontal");
        float vert_in = Input.GetAxisRaw("Vertical");
        Debug.Log(horz_in);

        if(x_bound >= 20 && horz_in < 0 || x_bound <= -20 && horz_in > 0 || x_bound < 20 && x_bound > -20)
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
            this.gameObject.transform.Translate(input);
        }
        if(y_bound >= 10 && vert_in < 0 || y_bound <= -10 && vert_in > 0 || y_bound < 10 && y_bound > -10)
        {
            Vector3 input = new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
            this.gameObject.transform.Translate(input);
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet_clone;
            bullet_clone = Instantiate(bullet_obj, this.transform.position, this.transform.rotation);
            bullet_clone.AddComponent<bullet>();
            Debug.Log("Fire");
        }
    }
}
