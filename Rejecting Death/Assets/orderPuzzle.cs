using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderPuzzle : MonoBehaviour
{
    [SerializeField]
    public int[] correctOrder;

    public int[] playerGuess;

    int i;
    public int correctCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
       // playerGuess = new int[correctOrder.Length];
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }



    public  void getValue(int value)
    {

        int g = correctOrder.Length;


        playerGuess[i]  = value;

        i = i+ 1;

        
        if (i == g)
        {
            check();
           // i = 0;
        }

    }
    void check()
    {
        for (int g = 0; g <= playerGuess.Length; g++)
        {
            if (playerGuess[g] == correctOrder[g])
            {
                correctCount += 1;
            }
        }

        if (correctCount == correctOrder.Length)
        {
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("WRONG");
            foreach (int i in playerGuess)
                playerGuess[i] = 0;

            i = 0;
            correctCount = 0;

        }
    }

}
