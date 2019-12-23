using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour {

    public GameObject Player;
	void Start () {
        Player.transform.position = transform.position;
	}

}
