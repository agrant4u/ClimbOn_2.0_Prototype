using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sUiNavigation : MonoBehaviour
{

    
    
    public void OnPlayButtonPressed()
    {

        //add a move to new scene code
        Destroy(this.gameObject);

        GameManager.gm.LoadScene(eScene.inGame);

    }







}
