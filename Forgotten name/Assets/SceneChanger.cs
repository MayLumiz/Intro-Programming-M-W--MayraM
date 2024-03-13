using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //use Scene Management Library

public class SceneChanger : MonoBehaviour
{
    //CCNY MW IN CLASS

    //GLOBAL VARIABLES
    public int sceneNumber; //essentially does the same thing as sceneID in the Build Settings
        //0 = StartScene
        //1 = MainScene
        //2 = EndScene

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneNumber == 0) //we're in the start scene
        {
            StartSceneControls(); //call StartSceneControls()
        } else if (sceneNumber == 1) //we're in the main scene
        {
            MainSceneControls(); //call MainSceneControls()
        } else if (sceneNumber == 2) //we're in the end scene
        {
            EndSceneControls(); //call EndSceneControls()
        }

    }

    public void StartSceneControls()
    {
        if (Input.GetKeyDown(KeyCode.Return)) //if Return/Enter is pressed...(You can change this key code!)
        {
            SceneManager.LoadScene("MainScene"); //load the MainScene
        }
    }

    public void MainSceneControls()
    {
        if (Input.GetKeyDown(KeyCode.Return)) //if Return/Enter is pressed...(You can change this key code!)
        {
            SceneManager.LoadScene("EndScene"); //load the EndScene
        }
    }

    public void EndSceneControls()
    {
        if (Input.GetKeyDown(KeyCode.Return)) //if Return/Enter is pressed...(You can change this key code!)
        {
            SceneManager.LoadScene("MainScene"); //load the StartScene
        }
    }
}