using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataBase : MonoBehaviour {
    public enum actions { move_up, move_down, move_left, move_right };

    public Text queue_contains;
    public GameObject game_over;
    public GameObject next_level;

    static public Queue actions_queue = new Queue();
    int max_queue_chargs = 20;
    static int queue_charge = 20;

    public const float multiplayer = 5;

    public void AddToQueue(actions act)
    {
        if (actions_queue.Count < queue_charge)
        {
            actions_queue.Enqueue(act);
        }
    }

    public void UpdateQueue()
    {
        string temp_str = "" + actions_queue.Count + "/" + queue_charge + "\n";

        foreach (actions act in actions_queue)
        {
            temp_str = temp_str + act;
            temp_str = temp_str + "\n";
        }
        queue_contains.text = temp_str;
        queue_contains.transform.parent.Find("Queue_Text_Shadow").GetComponent<Text>().text = temp_str;

        if (queue_charge <= 0)
        {
                queue_charge = max_queue_chargs;
                game_over.SetActive(true);
                
        }
    }

    public void DecraseCharges()
    {
        queue_charge--;
    }

    public void IncraseCharges(int ExtraChargs)
    {
        if (queue_charge + ExtraChargs < max_queue_chargs)
        {
            queue_charge = queue_charge + ExtraChargs;
        }
        else
        {
            queue_charge = max_queue_chargs;
        }
    }
}
