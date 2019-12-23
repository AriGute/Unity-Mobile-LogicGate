using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFX : MonoBehaviour {


    float timeLeft;
    Color targetColor;

    void Update () {
        if (timeLeft <= Time.deltaTime)
        {
            // transition complete
            // assign the target color
            GetComponent<Camera>().backgroundColor = targetColor;

            // start a new transition
            targetColor = new Color(Random.value, Random.value, Random.value);
            timeLeft = 5f;
        }
        else
        {
            // transition in progress
            // calculate interpolated color
            GetComponent<Camera>().backgroundColor = Color.Lerp(GetComponent<Camera>().backgroundColor, targetColor, Time.deltaTime / timeLeft);

            // update the timer
            timeLeft -= Time.deltaTime;
        }
 
    }
}
