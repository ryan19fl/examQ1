using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{
    public void playgame()
    {
        SceneManager.LoadScene("level1");
    }
    public void quitgame()
    {
        SceneManager.LoadScene("quit");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
