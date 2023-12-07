using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class brujula : MonoBehaviour
{
    public TMP_Text texto;
    LocationInfo GPSdata;
    // Start is called before the first frame update
    void Start() {
        Input.gyro.enabled = true;
        Input.compass.enabled = true;
        Input.location.Start();
        texto = GameObject.FindWithTag("texto").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update() {
        GPSdata = Input.location.lastData;
        texto.text = $"Angular velocity: {Input.gyro.rotationRate}\nTrueHeading: {Input.compass.trueHeading}\nAcceleration: {Input.acceleration}\nLatitud: {GPSdata.latitude}\n" +
        $"Longitud: {GPSdata.longitude}\nAltitud: {GPSdata.altitude}\n";
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,-Input.compass.trueHeading,0), 0.5f);
    }
}
