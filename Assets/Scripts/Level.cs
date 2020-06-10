using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform spawnPoint;
    public int startinglives;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.life = startinglives;
        GameManager.instance.SpawnPlayer(spawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
