using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer1 : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
	
	// Update is called once per frame
	void Update () {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, player.transform.position.y, player.transform.position.z);
	}
}
