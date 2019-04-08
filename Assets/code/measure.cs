using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;

public class measure : MonoBehaviour
{
    public GameObject ship;
    SerialPort serial;
    float roll = 0.0f;
    float pitch = 0.0f;
    float x_dist = 0.0f;
    float y_dist = 0.0f;
    Vector3 ship_pos;

    void Start()
    {
        serial = new SerialPort("\\\\.\\COM3", 9600);
        serial.Open();
        ship_pos = ship.transform.position;
    }
    void Update()
    {
        if (serial.IsOpen)
        {
            Debug.Log(serial.ReadLine());
            string raw_reading = serial.ReadLine();
            string[] measurements = raw_reading.Split(',');
            roll = float.Parse(measurements[0]);
            pitch = float.Parse(measurements[1]);
            x_dist = 20f * (pitch / 180.0f);
            y_dist = 20f * (roll / 180.0f);
            ship.transform.eulerAngles = new Vector3(-roll, 0.0f, -pitch);
            ship.transform.Translate(x_dist * Time.deltaTime, y_dist*Time.deltaTime, 0.0f, Space.World);
        }
        else
        {
            Debug.Log("Oh FUck");
        }
    }
}
