using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    float value = 0;
    public float Speed = 1;
    public bool only_z_axis = false;

	void Update () {
        if(value < 360)
        {
            value += Time.deltaTime;
        }
        else
        {
            value = 0;
        }
        if (only_z_axis == false)
        {
            transform.eulerAngles = new Vector3(value * 5 * Speed, 0, value * 10 * Speed);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, value * 10 * Speed);

        }
    }
}
