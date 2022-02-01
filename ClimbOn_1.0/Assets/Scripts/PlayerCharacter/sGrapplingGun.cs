using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sGrapplingGun : MonoBehaviour
{

    public GameObject pPlayer;
    sCharacterController player;

    private LineRenderer lr;
    private Vector3 grapplingPoint;
    public LayerMask whatIsGrappleable;

    public Transform gunTip, playerPos;
    private float maxDistance = 100f;
    private SpringJoint joint;

    public float pullTime = 3f;


    private void Awake()
    {

        player = pPlayer.GetComponent<sCharacterController>();
        lr = GetComponent<LineRenderer>();
        playerPos = pPlayer.transform;
        

    }


    public void StartGrapple()
    {

        Debug.Log("Grapple Control triggered");

        RaycastHit hit;

        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, maxDistance, whatIsGrappleable))
            {

            Debug.Log("Starting Grapple Hook");

            grapplingPoint = hit.point;
            player.isGrappling = true;

            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplingPoint;

            float distanceFromPoint = Vector3.Distance(pPlayer.transform.position, grapplingPoint);

            // DISTANCE GRAPPLE WILL TRY TO KEEP FROM GRAPPLE POINT
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            // CHANGE THESE UP TO FEEL RIGHT
            joint.spring = 4.5f;  //pull /push
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;

            }

    }

    void DrawRope()
    {

        if (!joint) return;

        
            lr.SetPosition(0, gunTip.position);
            lr.SetPosition(1, grapplingPoint);

        


    }

    public void StopGrapple()
    {

        Debug.Log("Stoping Grapple Hook");

        if (joint)
        {

            player.transform.position = Vector3.Lerp(player.transform.position,
                                                   grapplingPoint,
                                                   10f);

            //StartCoroutine("GrappleMove");
           
        }

        lr.positionCount = 0;

        player.isGrappling = false;
        
        Destroy(joint);

    }

    IEnumerator GrappleMove()
    {


            player.transform.position = Vector3.Lerp(player.transform.position,
                                                    grapplingPoint,
                                                    10f);


            yield return new WaitForSeconds(1);
        
        

    }

    public bool isGrappling()
    {

        return joint != null;

    }

    public Vector3 GetGrapplePoint()
    {

        return grapplingPoint;

    }

    private void Update()
    {

       

    }

    private void LateUpdate()
    {

        DrawRope();

    }

}
