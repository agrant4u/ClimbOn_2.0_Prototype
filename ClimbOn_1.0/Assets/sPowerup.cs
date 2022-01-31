using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum powerupType { SPEED_BURST, STAMINA_BOOST, STAMINA_BUFF}

public class sPowerup : MonoBehaviour
{

    public powerupType currentPowerupType;

    sCharacterController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        player = collision.gameObject.GetComponent<sCharacterController>();

        if (player)
        {

            InitPowerup();


        }



    }


    void InitPowerup()
    {

        switch(currentPowerupType)
        {

            case powerupType.SPEED_BURST:

                break;

            case powerupType.STAMINA_BOOST:

                break;

            case powerupType.STAMINA_BUFF:

                break;


        }

    }

    void SpeedBurst()
    {
        
    }

    void StaminaBoost()
    {

    }

    void StaminaBuff()
    {

    }

}
