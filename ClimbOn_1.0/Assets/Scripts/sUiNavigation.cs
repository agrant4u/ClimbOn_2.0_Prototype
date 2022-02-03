using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sUiNavigation : MonoBehaviour
{
    
    public void OnPlayButtonPressed()
    {

        //add a move to new scene code
        Destroy(this.gameObject);

        GameManager.gm.LoadScene("ClimbOn_3.0");

    }







}
