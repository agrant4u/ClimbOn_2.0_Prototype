using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sSpikeBehavior : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {

        sCharacterController player;

        player = collision.gameObject.GetComponent<sCharacterController>();

        if(player)
        {

            sCharacterController.isDead = true;

        }

    }

}
