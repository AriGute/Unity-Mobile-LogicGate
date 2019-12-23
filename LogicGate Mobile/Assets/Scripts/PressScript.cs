using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressScript : MonoBehaviour {
    public GameObject Gate;
    public bool Activated = false;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.red);
    }

    public void Activate_Button()
    {
        if (Activated)
        {
            Activated = false;
            rend.material.SetColor("_Color", Color.red);
            Gate.GetComponent<Activate>().Open();
        }
        else
        {
            Activated = true;
            rend.material.SetColor("_Color", Color.green);
            Gate.GetComponent<Activate>().Open();
        }
    }
}
