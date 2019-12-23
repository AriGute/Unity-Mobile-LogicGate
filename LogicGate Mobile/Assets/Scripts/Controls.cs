using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controls : DataBase
{
    float timer = 0;
    const float action_time = 1.5f;
    const float step = 1.3f;

    public GameObject player;
    public GameObject Buttons;


    void Start () {
        timer = action_time;
    }
	

    void TurnButtons()
    {
        if(Buttons.active == true)
        {
            Buttons.SetActive(false);
        }
        else
        {
            Buttons.SetActive(true);
        }
    }
	
	public IEnumerator StartActions() {
        TurnButtons();
        while (actions_queue.Count > 0)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime * multiplayer;
            }
            if (timer <= 0)
            {
                actions act = (actions)actions_queue.Dequeue();
                print("action: " + act);
                switch (act)
                {
                    case actions.move_up:
                        print("start move up:");
                        if (!WallCheck(new Vector3(0, 0, 1)))
                        {
                            StartCoroutine(MoveUp());
                        }
                        break;

                    case actions.move_down:
                        print("start move down:");
                        if (!WallCheck(new Vector3(0, 0, -1)))
                        {
                            StartCoroutine(MoveDown());
                        }
                        break;

                    case actions.move_left:
                        print("start move left:");
                        if (!WallCheck(new Vector3(-1, 0, 0)))
                        {
                            StartCoroutine(MoveLeft());
                        }
                        break;

                    case actions.move_right:
                        print("start move right:");
                        if (!WallCheck(new Vector3(1, 0, 0)))
                        {
                            StartCoroutine(MoveRight());
                        }
                        break;
                }
                ButtonCheck();
                timer = action_time;
                DecraseCharges();
                UpdateQueue();

            }

            yield return null;
        }
         TurnButtons();
	}


    IEnumerator MoveUp() {
        float timer = step;
        while (timer > 0)
        {

            player.transform.Find("caracter").gameObject.transform.eulerAngles = new Vector3(0,0,0);
            player.transform.Translate(Vector3.forward * Time.deltaTime * multiplayer);
            timer -= Time.deltaTime * multiplayer;
            yield return null;
        }
        print("end move up:");
    }

    IEnumerator MoveDown()
    {
        float timer = step;
        while (timer > 0)
        {
            player.transform.Find("caracter").gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
            player.transform.Translate(-Vector3.forward * Time.deltaTime * multiplayer);
            timer -= Time.deltaTime * multiplayer;
            yield return null;
        }
        print("end move down:");
    }

    IEnumerator MoveLeft()
    {
        float timer = step;
        while (timer > 0)
        {
            player.transform.Find("caracter").gameObject.transform.eulerAngles = new Vector3(0, 270, 0);
            player.transform.Translate(Vector3.left * Time.deltaTime * multiplayer);
            timer -= Time.deltaTime * multiplayer;
            yield return null;
        }
        print("end move left:");
    }

    IEnumerator MoveRight()
    {
        float timer = step;
        while (timer > 0)
        {
            player.transform.Find("caracter").gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
            player.transform.Translate(Vector3.right * Time.deltaTime * multiplayer);
            timer -= Time.deltaTime * multiplayer;
            yield return null;
        }
        print("end move right:");
    }


    void ButtonCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, new Vector3(0, -1, 0), out hit, 1f))
        {
            if (hit.transform.tag == "Button")
            {
                hit.transform.GetComponent<PressScript>().Activate_Button();
            }
            else if (hit.transform.tag == "ChargStand")
            {
                ChargsPress charge_press = hit.transform.GetComponent<ChargsPress>();
                if (charge_press.Charged == true)
                {
                    IncraseCharges(charge_press.charges_capacity);
                    charge_press.Charg();
                }
            }
            else if (hit.transform.tag == "Finish")
            {
                next_level.active = true;
                Buttons.active = true;
                GetComponent<Controls>().enabled = false;
                
            }
        }
    }

    bool WallCheck(Vector3 vec3)
    {
        RaycastHit hit;
        if(Physics.Raycast(player.transform.position, vec3, out hit, 1f))
        {
            print("wallCheck: true." + hit.transform.name);
            if (hit.transform.tag == "Wall")
            {
                return true;
            }
            return false;
        }
        print("wallCheck: false.");
        return false;
    }
}
