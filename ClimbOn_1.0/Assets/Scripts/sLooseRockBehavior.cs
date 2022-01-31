using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sLooseRockBehavior : MonoBehaviour
{

    public float rockFallForce;
    public float rockKnockdownForce;

    public float fallOffset;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

    }

    private void OnCollisionEnter(Collision collision)
    {

        sCharacterController player;

        player = collision.gameObject.GetComponent<sCharacterController>();

        if (player)
        {

            Debug.Log("Loose Rock triggered by " + player.name);

            // SHOOTS ROCK OUT
            rb.useGravity = true;
            rb.AddForce(0, 0, -rockFallForce, ForceMode.Impulse);

            // KNOCKS PLAYER DOWN
            player.GetComponent<Rigidbody>().AddForce(0, -rockKnockdownForce, 0, ForceMode.Impulse);

            //Vector3 currentPos = player.gameObject.transform.position;
            //Vector3 fallPos = new Vector3(currentPos.x, currentPos.y - fallOffset, currentPos.z);

            //collision.gameObject.transform.position = Vector3.Lerp(currentPos, fallPos, 15f * Time.fixedDeltaTime);

        }

    }

}
