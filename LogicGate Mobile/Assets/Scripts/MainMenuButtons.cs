﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {
    public void StartGame()
    {
        SceneManager.LoadScene("Level_1");
    }
}
