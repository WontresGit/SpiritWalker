using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEntry : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject displayed;
    void Start()
    {
        //displayed.SetActive(true);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            displayed.SetActive(false);
        }
    }
}
