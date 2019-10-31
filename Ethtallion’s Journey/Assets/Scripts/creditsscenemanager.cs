using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class creditsscenemanager : MonoBehaviour
{
    public string currentScene;
    public string[] sceneList = { "MainMenu", "IntroLevel" };
    public int currentSceneIndex;

    

    
    // Start is called before the first frame update
    void Start()
    {
        
        currentScene = SceneManager.GetActiveScene().name;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SelectLevel()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
