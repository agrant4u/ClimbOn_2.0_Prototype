using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sUiNavigation : MonoBehaviour
{

    GameManager gm;

    private void Start()
    {

        gm = GameManager.gm;

    }

    public void OnPlayButtonPressed()
    {

        //add a move to new scene code
        Destroy(this.gameObject);

        gm.LoadScene(eScene.inGame);

    }







}
