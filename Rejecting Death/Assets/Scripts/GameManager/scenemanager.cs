using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scenemanager : MonoBehaviour
{
    public int next;
    // Start is called before the first frame update
    void Start()
    {
        next = next + 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Changelvl()
    {
        SceneManager.LoadScene(next);
    }

}
