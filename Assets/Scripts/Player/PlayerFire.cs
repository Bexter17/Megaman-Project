using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public SpriteRenderer Megaman;

    
    public Transform spawnPointLeft;
    public Transform spawnpoint;
    public float projectileSpeed;
    public Projectile projectilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        if (projectileSpeed <= 0)
        {
            projectileSpeed = 7.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shot();
        }
    }

    void shot()
    {
        if (Megaman.flipX)
        {
           Projectile temp = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            temp.speed = -projectileSpeed;
        }
        else
        {
             Instantiate(projectilePrefab, spawnpoint.position, spawnpoint.rotation);
        }
       // Projectile temp = Instantiate(projectilePrefab, spawnpoint.position, spawnpoint.rotation);

       // temp.speed = -projectileSpeed;
    }
}
