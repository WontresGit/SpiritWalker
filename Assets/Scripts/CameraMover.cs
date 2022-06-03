using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public GameObject player;
    public Camera thisCamera;
    public float cameraSpeed = 4f;
    private Vector2 startPos;
    private Vector3 newPosition;

    private float height;
    private float width;

    public void fastSetPosition(float pos, float diff)
    {
        thisCamera.transform.position = new Vector3(pos, thisCamera.transform.position.y, thisCamera.transform.position.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        height = thisCamera.orthographicSize * 2;
        width = thisCamera.aspect * height;

        startPos = thisCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = startPos;
        pos.x += Mathf.Floor((player.transform.position.x - (startPos.x - width / 2)) / width) * width;
        pos.y += Mathf.Floor((player.transform.position.y - (startPos.y - height/2)) / height) * height;
        newPosition = new Vector3(pos.x, pos.y, thisCamera.transform.position.z);
        thisCamera.transform.position += (newPosition - thisCamera.transform.position) * cameraSpeed * Time.deltaTime;

        //Vector2 pos = player.transform.position;
        //pos.x = Mathf.Floor(pos.x / width) * width - 4 * delta.x;
        //pos.y = Mathf.Floor(pos.y / height) * height - 2 * delta.y;
        //newPosition = new Vector3(pos.x, pos.y, thisCamera.transform.position.z);
        //thisCamera.transform.position += (newPosition - thisCamera.transform.position) * cameraSpeed * Time.deltaTime;
    }

    void OnDrawGizmos()
    {
        // Gizmos.color = Color.red;
       // Gizmos.DrawWireSphere(thisCamera.transform.position, thisCamera.orthographicSize);
    }

}
