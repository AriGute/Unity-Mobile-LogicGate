using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : DataBase
{
    public GameObject Player_controller;
    public GameObject helpTable;
    Controls pc;
    


    void Start()
    {
        pc = Player_controller.GetComponent<Controls>();
    }

    public void Start_Action()
    {
       StartCoroutine(pc.StartActions());
    }

    public void MoveUp()
    {

        AddToQueue(actions.move_up);
        UpdateQueue();
    }

    public void MoveDown()
    {
        AddToQueue(actions.move_down);
        UpdateQueue();
    }

    public void MoveLeft()
    {
        AddToQueue(actions.move_left);
        UpdateQueue();
    }

    public void MoveRight()
    {
        AddToQueue(actions.move_right);
        UpdateQueue();
    }

    public void Restart()
    {
        print("work");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenHelp()
    {
        if (helpTable.active == false)
        {
            helpTable.active = true;
        }
        else
        {
            helpTable.active = false;
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        IncraseCharges(20);
    }
}
