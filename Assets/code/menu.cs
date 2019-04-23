using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public data data_obj;
    public Toggle keyboard;
    public Toggle controller;

    // Start is called before the first frame update
    void Start()
    {
        keyboard.isOn = true;
        controller.isOn = false;
        data_obj.keyboard = true;
        data_obj.controller = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick()
    {
        SceneManager.LoadScene("scene_1");
    }

    public void OnToggle(Toggle change)
    {
        if(change.name == "Keyboard")
        {
            if (change.isOn)
            {
                controller.isOn = false;
                data_obj.controller = false;
                data_obj.keyboard = true;
            }
            else
            {
                controller.isOn = true;
                data_obj.controller = true;
                data_obj.keyboard = false;

            }
        }
        if(change.name == "Controller")
        {
            if (change.isOn)
            {
                keyboard.isOn = false;
                data_obj.keyboard = false;
                data_obj.controller = true;
            }
            else
            {
                keyboard.isOn = true;
                data_obj.keyboard = true;
                data_obj.controller = false;
            }
        }
    }
}
