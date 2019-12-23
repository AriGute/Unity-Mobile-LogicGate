using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : DataBase
{
    public enum logic_gate { or, and, nor, nand };
    public List<PressScript> Activate_Buttons = new List<PressScript>();
    public logic_gate gate_type;
    public Transform Target;
    public GameObject obj;
    Vector3 start_pos;
    const float step = 3;

    Renderer rend;
    void Start()
    {

        rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.red);
        

        if (obj == null)
        {
            obj = this.gameObject;
        }
        start_pos = obj.transform.position;
        foreach (PressScript PS in Activate_Buttons)
        {
            PS.Gate = this.gameObject;
        }

        Open();
    }
    public void Open()
    {
        bool unlock = false;

        switch (gate_type)
        {

            case logic_gate.and:
                unlock = true;
                foreach (PressScript PS in Activate_Buttons)
                {
                    if (PS.Activated == false)
                    {
                        unlock = false;
                        break;
                    }
                }
                break;

            case logic_gate.nand:
                unlock = true;
                foreach (PressScript PS in Activate_Buttons)
                {
                    if (PS.Activated != false)
                    {
                        unlock = false;
                        break;
                    }
                }
                break;

            case logic_gate.or:
                unlock = false;
                foreach (PressScript PS in Activate_Buttons)
                {
                    if (PS.Activated == true)
                    {
                        unlock = true;
                        break;
                    }
                }
                break;

            case logic_gate.nor:
                unlock = false;
                foreach (PressScript PS in Activate_Buttons)
                {
                    if (PS.Activated != true)
                    {
                        unlock = true;
                        break;
                    }
                }
                break;
        }

        if (unlock)
        {
            print("work1");
            StartCoroutine(Move_target(start_pos, Target.position));
            rend.material.SetColor("_Color", Color.green);
        }
        else
        {
            print("work2");
            StartCoroutine(Move_target(Target.position, start_pos));
            rend.material.SetColor("_Color", Color.red);
        }
    }

    IEnumerator Move_target(Vector3 start_pos, Vector3 end_pos)
    {
        print(Vector3.Distance(obj.transform.position, end_pos));
        while (Vector3.Distance(obj.transform.position, end_pos) > 0.1f)
        {

            obj.transform.position = Vector3.MoveTowards(obj.transform.position, end_pos, step * Time.deltaTime * multiplayer);
            yield return null;
        }
    }
}
