using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public enum CollectibleType { HEALTH, LIVES, ENERGY, DAMAGE }

    public CollectibleType type;
    
   
    GameManager instance;

    


    // Start is called before the first frame update
    void Start()
    {
        instance = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (type)
            {
                case CollectibleType.HEALTH:
                    instance.health++;
                    Destroy(gameObject);
                    break;
                case CollectibleType.LIVES:                     
                    Destroy(gameObject);
                    break;
                case CollectibleType.ENERGY:
                    break;
                case CollectibleType.DAMAGE:
                    break;
            }

        }
    }
}
