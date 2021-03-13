using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public  int score = 0;
     int  next = 1, curent =1;
    // Start is called before the first frame update
    void Start()
    {
        

        if (instance == null)
        { 
        instance = this;
        }
        
      if (instance != this)
        { Destroy(gameObject); }
       DontDestroyOnLoad(gameObject);

        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score == 2)
        {
            SceneManager.LoadScene(curent + 1);
            curent = curent + next;
            score = 0;
        }
    }
    public void AddScore(int amount)
    {
        score += amount;
    }
    public void Death()
    {
        score = 0;
        SceneManager.LoadScene(2);
    }
    
    }
