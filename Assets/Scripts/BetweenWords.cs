using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenWords : MonoBehaviour
{
    public Camera camMain, camSpirit;
    private GameObject playerMain, playerSpirit;
    private float diff;

    // Start is called before the first frame update
    void Start()
    {
        camMain.enabled = true;
        camSpirit.enabled = false;
        playerMain = GameObject.FindGameObjectWithTag("Player");
        playerSpirit = GameObject.FindGameObjectWithTag("UnactivePlayer");
        playerMain.tag = "Player";
        playerSpirit.tag = "UnactivePlayer";
        diff = playerMain.transform.position.y - playerSpirit.transform.position.y;
        camMain.GetComponent<AudioSource>().enabled = true;
        camSpirit.GetComponent<AudioSource>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            camMain.enabled = !camMain.enabled;
            camSpirit.enabled = !camSpirit.enabled;
            camMain.GetComponent<AudioSource>().enabled = !camMain.GetComponent<AudioSource>().enabled;
            camSpirit.GetComponent<AudioSource>().enabled = !camSpirit.GetComponent<AudioSource>().enabled;
            playerMain.tag = (playerMain.tag == "Player") ? "UnactivePlayer" : "Player";
            playerSpirit.tag = (playerMain.tag == "Player") ? "UnactivePlayer" : "Player";

            if(playerSpirit.tag.Equals("Player"))
            {
                Vector3 t = playerSpirit.transform.position;
                playerSpirit.transform.position = new Vector3(playerMain.transform.position.x, playerMain.transform.position.y - diff, t.z);
                playerSpirit.GetComponent<SpriteRenderer>().flipX = playerMain.GetComponent<SpriteRenderer>().flipX;
                camSpirit.GetComponent<CameraMover>().fastSetPosition(camMain.transform.position.x, diff);
            }
            else
            {
                Vector3 t = playerMain.transform.position;
                playerMain.transform.position = new Vector3(playerSpirit.transform.position.x, playerSpirit.transform.position.y + diff, t.z);
                playerMain.GetComponent<SpriteRenderer>().flipX = playerSpirit.GetComponent<SpriteRenderer>().flipX;
                camMain.GetComponent<CameraMover>().fastSetPosition(camSpirit.transform.position.x, diff);
            }
            //Debug.Log(playerMain.tag);
        }
    }
}
