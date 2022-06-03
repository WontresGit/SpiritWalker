using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {
    // Attach this to your checkpoints. Checkpoints should have a collider 2D set to trigger.
    // If you want to make a sprite animate on activating the checkpoint, let me know! It shouldn't be too hard to program.
    [HideInInspector]
    public GameObject respawn;
    // private GameObject respawnSpirit;
    private bool activated = false;
    public bool isSpirit = false;
    public GameObject paired;
	
	void Start () {
        respawn = GameObject.FindGameObjectWithTag("Respawn");
        if (isSpirit)
        {
            respawn = GameObject.FindGameObjectWithTag("RespawnSpirit");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated)
        {
            if (collision.CompareTag("Player") || collision.CompareTag("UnactivePlayer"))
            {
                respawn.transform.position = transform.position;
                paired.GetComponent<CheckPoint>().respawn.transform.position = paired.GetComponent<CheckPoint>().transform.position;
            }
        }
    }

}
