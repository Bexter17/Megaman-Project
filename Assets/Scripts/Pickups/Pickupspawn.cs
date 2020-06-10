using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupspawn : MonoBehaviour
{

    public GameObject Healthprefab;
    public GameObject Lifeupprefab;



    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, 3);

        if (random == 0)
        {
            Instantiate(Healthprefab, gameObject.transform.position, gameObject.transform.rotation);

        }
        else if (random == 1)
        {
            Instantiate(Lifeupprefab, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
