using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;

public class measure : MonoBehaviour
{
    public GameObject ship;
    public GameObject bullet_obj;
    SerialPort serial;
    float roll = 0.0f;
    float pitch = 0.0f;
    float x_dist = 0.0f;
    float y_dist = 0.0f;
    bool sync_flag;

    void Start()
    {
        serial = new SerialPort("\\\\.\\COM3", 9600);
        serial.Open();
        sync_flag = false;
    }
    void Update()
    {
        if (serial.IsOpen)
        {
            if(sync_flag == false)
            {
                serial.Write("sync");
                Pause();
                try
                {
                    string raw_reading = serial.ReadLine();
                    if (raw_reading == "ack")
                    {
                        sync_flag = true;
                    }
                }
                catch (TimeoutException) { }
            }
            else
            {
                serial.Write("send");
                /*
                try
                {
                    string raw_reading = serial.ReadLine();
                    string[] measurements = raw_reading.Split(',');
                    roll = float.Parse(measurements[0]);
                    pitch = float.Parse(measurements[1]);
                    x_dist = 20f * (pitch / 180.0f);
                    y_dist = 20f * (roll / 180.0f);
                    ship.transform.eulerAngles = new Vector3(-roll, 0.0f, -pitch);
                    //ship.transform.Translate(x_dist * Time.deltaTime, y_dist * Time.deltaTime, 0.0f, Space.World);
                }
                catch (TimeoutException) { }
                */
                string raw_reading = serial.ReadLine();
                string[] measurements = raw_reading.Split(',');
                roll = float.Parse(measurements[0]);
                pitch = float.Parse(measurements[1]);
                x_dist = 20f * (pitch / 180.0f);
                y_dist = 20f * (roll / 180.0f);
                ship.transform.eulerAngles = new Vector3(-roll, 0.0f, -pitch);

            }
        }
        else
        {
            Debug.Log("Broken");
        }
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet_clone;
            bullet_clone = Instantiate(bullet_obj, ship.transform.position, ship.transform.rotation);
            bullet_clone.AddComponent<bullet>();
            Debug.Log("Fire");
        }
    }
    IEnumerator Pause()
    {
        yield return new WaitForSeconds(.2f);
    }
}
