using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPool : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private List<GameObject> laserList;
    [SerializeField] private int poolSize = 10;


    private static LaserPool instance;
    public static LaserPool Instance
    {
        get { return instance; }
    }
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            
        }

    }


    void Start()
    {
       AddLaserToPool(poolSize);
    }

    private void AddLaserToPool(int amout)
    {
        for (int i = 0; i < amout; i++)
        {
            GameObject laser = Instantiate(laserPrefab);
            laser.SetActive(false);
            laserList.Add(laser);
            laser.transform.parent = transform;
        }
    }

    public GameObject RequestLaser()
    {
        for (int i = 0; i < laserList.Count; i++)
        {
            if (!laserList[i].activeSelf)
            {
                laserList[i].SetActive(true);
                return laserList[i];
            }
        }
        AddLaserToPool(1);
        laserList[laserList.Count -1 ].SetActive(true);
        return laserList[laserList.Count - 1];

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
