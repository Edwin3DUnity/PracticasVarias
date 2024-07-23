using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField] private float laserSpeed = 5f;

    [SerializeField] private Rigidbody2D laserRigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        laserRigidbody2D.velocity = Vector2.up *laserSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
