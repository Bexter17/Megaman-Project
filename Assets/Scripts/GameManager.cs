using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int _health;
    int _life;

    public int maxLife;

    // Start is called before the first frame update
    void Start()
    {
        life = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int health
    {
        get { return _health; }
        set
        {
            _health = value;
            Debug.Log("Health has increased to " + _health);
        }
    }

    public int life
    {
        get { return _life; }
        set
        {
            _life = value;
            if (_life > maxLife)
                _life = maxLife;

            Debug.Log("Life has increased to " + _life);
        }
    }



}




