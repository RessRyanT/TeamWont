using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMnger : MonoBehaviour
{
    public string currentScene;
    public string[] sceneList = { "MainMenu", "IntroLevel" };
    public int currentSceneIndex;

    GameObject kirby;
    Camera mainCamera;
    Vector3 kirbposition;

    float vertExtent;
    float horzExtent;
    // Start is called before the first frame update
    void Start()
    {
        kirby = GameObject.FindObjectOfType<Wizard>().gameObject;
        mainCamera = GameObject.FindObjectOfType<Camera>();
        currentScene = SceneManager.GetActiveScene().name;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
         if(kirby.transform.position.y > 20 || kirby.transform.position.y < -20 || Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(currentSceneIndex);
            
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
