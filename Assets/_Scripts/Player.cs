using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   // [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float laserOfset = 0.5f;
    [SerializeField] private float playerSpeed = 10f;
    private Rigidbody2D _rigidbody2D;
    private float horizontalInput, verticalInput;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Fire1"))
        {
           // Instantiate(laserPrefab, transform.position + Vector3.up * laserOfset, Quaternion.identity);
           GameObject laser =  LaserPool.Instance.RequestLaser();
           laser.transform.position = transform.position + Vector3.up * laserOfset;
        }



    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * playerSpeed * Time.fixedDeltaTime;
        _rigidbody2D.MovePosition(_rigidbody2D.position + movement);
    }
}
