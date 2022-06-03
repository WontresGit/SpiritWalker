using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private float cooldownTimer = 0.0f;
    private float cooldown = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer > 0.0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
        if (cooldownTimer <= 0.0f)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.AddForce(Vector2.left * 1250.0f);
                cooldownTimer = cooldown;
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.AddForce(Vector2.left * -1250.0f);
                cooldownTimer = cooldown;
            }
        }
    }
}
