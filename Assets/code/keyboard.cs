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
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        this.gameObject.transform.Translate(input);
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet_clone;
            bullet_clone = Instantiate(bullet_obj, this.transform.position, this.transform.rotation);
            bullet_clone.AddComponent<bullet>();
            Debug.Log("Fire");
        }
    }
}
