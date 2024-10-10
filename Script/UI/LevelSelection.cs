using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public string LevelName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void changeLvl()
    {
        SceneManager.LoadScene(LevelName);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
