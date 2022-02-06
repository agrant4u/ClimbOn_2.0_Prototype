using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public enum eScene { mainMenu, inGame }


public class GameManager : MonoBehaviour
{
    void Start()
    {
        


    }
    public static GameManager gm;


    [Space]
    [Header("Scene Management")]
    int currentScene;
    public eScene curScene;
    int startScene = 0;



    public void LoadScene(string sceneName)
    {
        
        Debug.Log("sceneName to load: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }




}
