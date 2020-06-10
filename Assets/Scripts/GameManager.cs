using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;

    int _health;
    int _life;

    public int maxLife;

    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {

        if (_instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }


            life = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "TitleScreen")
            {
                SceneManager.LoadScene("SampleScene");
            }
            else if (SceneManager.GetActiveScene().name == "SampleScene")
            {
                SceneManager.LoadScene("GameOverScreen");
            }
            else if (SceneManager.GetActiveScene().name == "GameOverScreen")
            {
                SceneManager.LoadScene("TitleScreen");
            }
        }
        
    }

    public void SpawnPlayer(Transform spawnLocation)
    {
        Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);
    }

    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
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
            else if (_life < 0)
                SceneManager.LoadScene("GameOverScreen");

            Debug.Log("Life has increased to " + _life);
        }
    }



}




