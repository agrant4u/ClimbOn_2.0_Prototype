using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public enum PlayerControlState { CLIMBING, WALKING, FALLING, OVERHANGING, LEDGE,  }

public class sCharacterController : MonoBehaviour
{

    PlayerControls controller;

    [Space]
    [Header("Movement")]
    [SerializeField]public float climbSpeed = 5f;
    float startingClimbSpeed;
    //float totalClimbSpeed;

    float climbSlowDownAmount=0;

    [SerializeField] public float walkSpeed = 5f;
    float startingWalkSpeed;

    public float sprintMultiplier = 2f;

    public float speedBoostTime = 5f;

    [SerializeField] float jumpForce = 5f;
    bool isJumping;

    bool isOverHanging;

    public static bool isGettingBucked = false;

    [Space]
    [Header("Camera")]
    // CAMERA STUFF
    [SerializeField] Transform cameraTarget;
    Vector3 cameraPivot;
    Vector3 cameraOffset;
    //[SerializeField] float cameraSensitivity = 5f;
    // CINEMACHINE
    public GameObject camController;
    CinemachineFreeLook freeLookCam;
    public Camera cam;

    public GameObject reticle;
    Transform reticleStartingPos;
    float reticleSensitivity = 5f;

    Rigidbody rb;

    [Space]
    [Header("Player State")]
    [SerializeField] public PlayerControlState currentState = PlayerControlState.WALKING;

    float h = 0f;
    float v = 0f;

    bool jumpDown = false;

    Vector3 velo;

    [Space]
    [Header("Health")]
    public float maxHitPoints = 100; // make static?
    public static float currentHitPoints;
    public float fallKillDistance = 10f;

    public static bool isDead = false;

    [Space]
    [Header("Walk Stamina")]
    public static float maxStamina = 100;
    public static float currentStamina;
    [Space]
    public float staminaDrainPerSec = 5;
    public float staminaRecoveryPerSec = 2;
    bool isSprinting = false;
    bool isNotSprinting;

    [Space]
    [Header("Climb Stamina")]
    [Space]
    public float staminaClimbDrainPerSec = 5;
    public float staminaClimbRecoveryPerSec = 2;

    //public static sCharacterController globalPlayerReference;

    //public GameObject shoulderRight;
    //public GameObject shoulderLeft;

    //Animaton shoulderRightAnimator;
    // Animaton shoulderLeftAnimator;

    //public Transform[] checkPoints;
    //int checkPointPos;

    public Transform startingPosition;

    Vector3 currentCheckPointPosition;

    public GameObject masterPlayer;

    public Animator animController;
    public float animatorSpeed = 1; // DEFAULT 1

    public GameObject grappleGun;
    sGrapplingGun grappleGunBehavior;
    public bool isGrappling;


    void Awake()
    {

        // SETS STARTING PLAYER POSITION TO 1st CheckPoint or StartingPoint
        currentCheckPointPosition = startingPosition.position;
        grappleGunBehavior = grappleGun.GetComponent<sGrapplingGun>();

        Vector3 reticleStartingPos = reticle.transform.localPosition;

        //shoulderLeftAnimator = shoulderLeft.GetComponent<Animator>();
        //shoulderRightAnimator = shoulderRight.GetComponent<Animator>();

        //shoulderLeftAnimator.

        controller = new PlayerControls();

        freeLookCam = camController.GetComponent<CinemachineFreeLook>();
        // SET CAM ORBITS?
        animController = masterPlayer.GetComponent<Animator>();
        SetAnimatorSpeed(animatorSpeed);

        controller.Gameplay.Jump.performed += Jump;

        controller.Gameplay.GrappleShoot.performed += context => GrappleShoot();

        controller.Gameplay.Sprint.performed += context => Sprint();
        

        //controller.Gameplay.Sprint.canceled += NotSprinting;
        
        //controller.Gameplay.Sprint.

        //controller.Gameplay.Drop.performed += Drop;

        //controller.Gameplay.ArmRight.started += MoveRightArm;
        //controller.Gameplay.ArmRight.canceled += context => isLimbMoving = false;

        

    }

    private void OnEnable()
    {

        controller.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controller.Gameplay.Disable();
    }

    void Start()
    {

        //globalPlayerReference = this;
        isOverHanging = false;
        isJumping = false;
        isGrappling = false;
        rb = GetComponent<Rigidbody>();
        startingWalkSpeed = walkSpeed;
        currentHitPoints = maxHitPoints;
        currentStamina = maxStamina;


    }

    private void Update()
    {

        //CameraUpdate();

        // INPUT PER FRAME HERE
        Vector2 movement = controller.Gameplay.Movement.ReadValue<Vector2>();
        h = movement.x;
        v = movement.y;

        if (!jumpDown)
        {
            jumpDown = controller.Gameplay.Jump.triggered;
        }

        HealthCheck();

        ReticleUpdate();
        
    }

    void FixedUpdate()
    {
        //CameraFollow();

        MovementHandler();


    }

    void SetAnimatorSpeed(float _speed)
    {
        animController.speed = _speed;
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Hold"))
        {
            currentState = PlayerControlState.CLIMBING;
           
        }

    }

    // USE THIS TO INCREMENT AND SET NEXT CHECKPOINT POS
    public void SetNewCheckPoint(Vector3 _newCheckPointPosition)
    {
        //checkPointPos++;
        currentCheckPointPosition = _newCheckPointPosition;
        
    }

    void HealthCheck()
    {

        if (sCharacterController.isDead)
        {

            PlayerDeath();

        }

    }

    // NEEDS WORK!
    IEnumerator FallCheck()
    {

        Vector3 currentPos = gameObject.transform.position;
        Vector3 oldPos = currentPos;

        for (int i = 0; i < 10; i++)
        { 

            currentPos = gameObject.transform.position;
            float difference = currentPos.y - oldPos.y;

            // CHECKS FOR FALL DEATH
            if (difference >= fallKillDistance)
            {
                sCharacterController.isDead = true;
            }

            yield return new WaitForSeconds(0.2f);

        }

        


    }

    void PlayerDeath()
    {

        Vector3 offset = new Vector3(0, 1f, 0);
        gameObject.transform.position = currentCheckPointPosition + offset;
        sCharacterController.isDead = false;

    }

    void MovementHandler()
    {
        
        // THIS HANDLES MOVEMENT WITH LEFT STICK
        Vector2 input = controller.Gameplay.Movement.ReadValue<Vector2>();
        
        //Vector2 camInput = controller.Gameplay.Camera.ReadValue<Vector2>();
        Transform cam = Camera.main.transform;

        // SWITCHES INPUT TO X/Z Plane for Walking
        Vector3 walkDirection = Quaternion.FromToRotation(cam.up, Vector3.up)
                                * cam.TransformDirection(new Vector3(input.x, 0f, input.y));


        // MOVEMENT STATE TRANSITIONS
        switch (currentState)
        {
            case PlayerControlState.WALKING:
                {
                    WalkingMovement(walkDirection);
                    break;
                }
            case PlayerControlState.FALLING:
                {
                    FallingMovement(walkDirection);
                    break;
                }
            case PlayerControlState.CLIMBING:
                {                   
                    ClimbingMovement(input);
                    break;
                }
            case PlayerControlState.OVERHANGING:
                {
                    if (isOverHanging)
                    OverHangMovement(walkDirection);
                    break;
                }
        }

        // CHECKS FOR HIT DIRECTLY BELOW CHARACTER
        RaycastHit hit;
        if (Physics.Raycast(transform.position,
                            Vector3.down,
                            out hit,
                            1.02f))
        {
            Debug.Log("Raycast Hit below");

            currentState = PlayerControlState.WALKING;
            isJumping = false;
            isOverHanging = false;
        }

        else if (currentState == PlayerControlState.WALKING)
        {
            currentState = PlayerControlState.FALLING;
        }

        // CHECKS FOR HIT ABOVE CHARACTER
        if (Physics.Raycast(transform.position,
                         Vector3.up,
                         out hit, 1.02f))
        {

            Debug.Log("Raycast Hit above");

            currentState = PlayerControlState.OVERHANGING;
            isOverHanging = true;
            
            
        }

        else
        {
            //currentState = PlayerControlState.FALLING;
            isOverHanging = false;
            rb.useGravity = true;
        }

        //rb.useGravity = currentState != PlayerControlState.CLIMBING;

        // RESET INPUT
        jumpDown = false;

    }

    void ClimbingMovement(Vector2 _input)
    {

        float totalClimbSpeed = climbSpeed;

        Debug.Log("Climbing Happening");

        animController.SetBool("isClimbing", true);
        animController.SetBool("isFalling", false);

        // CHECK WALLS IN A CROSS PATTERN
        Vector3 offset = transform.TransformDirection(Vector2.one * 0.5f);
        Vector3 checkDirection = Vector3.zero;
        int k = 0;

        // RAYCASTS 4 times to check for direction AVG
        for (int i = 0; i < 4; i++)
        {

            RaycastHit checkHit;
            if (Physics.Raycast(transform.position + offset,
                                transform.forward,
                                out checkHit))
            {

                checkDirection += checkHit.normal;
                k++;
            }

            //ROTATE OFFSET BY 90 DEGREES
            offset = Quaternion.AngleAxis(90f, transform.forward) * offset;
        }

        checkDirection /= k;  // AVG OF THE RAYCASTS

        // CHECKS WALL DIRECTLY IN FRONT
        RaycastHit hit;
        if (Physics.Raycast(transform.position, // POSITION
                            -checkDirection,  // DIRECTION
                            out hit)) // HIT DATA
        {

            float dot = Vector3.Dot(transform.forward, -hit.normal);


            // SMOOTHES MOVEMENT ALONG THE WALL TO CURVE AROUND
            //transform.forward = -hit.normal;
            rb.position = Vector3.Lerp(rb.position,
                                       hit.point + hit.normal * 0.55f,
                                       5f * Time.fixedDeltaTime);

            transform.forward = Vector3.Lerp(transform.forward,
                                             -hit.normal,
                                             10f * Time.fixedDeltaTime);


            // WALL BEHAVIOR
            sWallBehavior wallBehavior;
            wallBehavior = hit.transform.gameObject.GetComponent<sWallBehavior>();
            
            if (wallBehavior)
            {

                // SETS SLOWDOWN AMOUNT BASED ON WALL BEHAVIOR
                climbSlowDownAmount = wallBehavior.CheckSlowDownState();


            }

            // MOVEMENT
            totalClimbSpeed = climbSpeed/climbSlowDownAmount;

            if (isSprinting)
            {

                SetAnimatorSpeed(animatorSpeed * sprintMultiplier);

                if (currentStamina > 0)
                {
                    Debug.Log("Sprinting happening");
                    totalClimbSpeed *= sprintMultiplier;
                    currentStamina -= staminaDrainPerSec * Time.fixedDeltaTime;
                }
            }

            else
            {
                SetAnimatorSpeed(animatorSpeed);
                Debug.Log("Not Sprinting");
                
                currentStamina += staminaRecoveryPerSec * Time.deltaTime;
                if (currentStamina > maxStamina)
                    currentStamina = maxStamina;
            }

            rb.useGravity = false;
            rb.velocity = transform.up * _input.y * totalClimbSpeed + transform.right * _input.x * totalClimbSpeed;

            if (jumpDown)
            {
                rb.velocity = Vector3.up * 5f + hit.normal * 2f;
                currentState = PlayerControlState.FALLING;
            }
        }

        else
        {
            currentState = PlayerControlState.FALLING;
            rb.useGravity = true;
        }
    }

    void OverHangMovement(Vector3 _moveDirection)
    {

        Debug.Log("OverHanging Movement Happening");

        animController.SetBool("isClimbing", false);
        animController.SetBool("isFalling", false);

        float totalWalkSpeed = walkSpeed;

        rb.useGravity = false;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, // POSITION
                            Vector3.up,  // DIRECTION
                            out hit)) // HIT DATA
        {

            //float dot = Vector3.Dot(transform.forward, -hit.normal);


            // SMOOTHES MOVEMENT ALONG THE WALL TO CURVE AROUND
            //transform.forward = -hit.normal;
            
            //rb.position = Vector3.Lerp(rb.position,
              //                        hit.normal,
                //                      Time.fixedDeltaTime);
            

            transform.up = Vector3.Lerp(transform.up,
                                             -hit.normal,
                                             Time.fixedDeltaTime);

            /* SPRINTING?
            if (isSprinting)
            {


                if (currentStamina > 0)
                {
                    Debug.Log("Sprinting happening");
                    totalWalkSpeed *= sprintMultiplier;
                    currentStamina -= staminaDrainPerSec * Time.fixedDeltaTime;
                }
            }

            else
            {
                Debug.Log("Not Sprinting");
                currentStamina += staminaRecoveryPerSec * Time.deltaTime;
                if (currentStamina > maxStamina)
                    currentStamina = maxStamina;
            }
            */

        }

        else
        {
            //isOverHanging = false;
        }

        Vector3 oldVelo = rb.velocity;

        Vector3 newVelo = _moveDirection * totalWalkSpeed;
        newVelo.y = oldVelo.y;

        if (jumpDown)
        {

            newVelo.y = 5f;
            //currentState = PlayerControlState.FALLING;
        }

        rb.velocity = newVelo;

        if (_moveDirection.sqrMagnitude > 0.01f)
        {

            transform.forward = _moveDirection;

        }

    }

    void WalkingMovement(Vector3 _moveDirection)
    {
        Debug.Log("Walking happening");

        animController.SetBool("isClimbing", false);
        animController.SetBool("isFalling", false);

        float totalWalkSpeed = walkSpeed;

        if (isSprinting)
        {
            SetAnimatorSpeed(animatorSpeed * sprintMultiplier);

            if (currentStamina > 0)
            {
                Debug.Log("Sprinting happening");
                totalWalkSpeed *= sprintMultiplier;
                currentStamina -= staminaDrainPerSec * Time.fixedDeltaTime;
            }
        }

        else
        {
            SetAnimatorSpeed(animatorSpeed);

            Debug.Log("Not Sprinting");
            currentStamina += staminaRecoveryPerSec * Time.deltaTime;
            if (currentStamina > maxStamina)
                currentStamina = maxStamina;
        }
            

        Vector3 oldVelo = rb.velocity;

        Vector3 newVelo = _moveDirection * totalWalkSpeed;
        newVelo.y = oldVelo.y;

        if (jumpDown)
        {

            newVelo.y = 5f;
            currentState = PlayerControlState.FALLING;
        }

        rb.velocity = newVelo;

        if (_moveDirection.sqrMagnitude > 0.01f)
        {

            transform.forward = _moveDirection;

        }
    }

    void FallingMovement(Vector3 _moveDirection)
    {
        Debug.Log("Falling happening");

        animController.SetBool("isFalling", true);

       

        if (_moveDirection.sqrMagnitude > 0.01f)
        {

            transform.forward = _moveDirection;

        }

        if (jumpDown && Physics.Raycast(transform.position,
                                        transform.forward*0.8f))
        {
            currentState = PlayerControlState.CLIMBING;
            animController.SetBool("isClimbing", true);
        }

    }

    void Sprint()  // USED FOR CONTROLS
    {

        isSprinting = !isSprinting;  // DONT CHANGE THIS
              
    }

    void Jump(InputAction.CallbackContext _context)  // JUMP ACTION.  FEET HAVE OTHER SCRIPT TO CHECK FOR GROUND COLLISION
    {

        Vector2 input = controller.Gameplay.Movement.ReadValue<Vector2>();

        if (!jumpDown)
        {
            Debug.Log("Jump");

            if(!isJumping)
            {
                // WALL JUMP
                if (currentState == PlayerControlState.CLIMBING)
                {
                    isJumping = true;
                    rb.AddForce(new Vector3(input.x * jumpForce, input.y * jumpForce, 0), ForceMode.Impulse);
                }

                //REGULAR WALK JUMP
                else if (currentState == PlayerControlState.WALKING)
                {
                    isJumping = true;
                    rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                }

            }        

        }

    }

    private bool isFacingWall()
    {
        //TODO: set angle threshold on wall facing

        RaycastHit hitInfo1, hitInfo2;
        LayerMask mask = LayerMask.GetMask("Default");

        //hard coding radius and player half height
        //cast at eye level
        Physics.SphereCast(transform.position + new Vector3(0, 0.25f, 0), 0.35f, transform.forward, out hitInfo1,
            0.5f, mask.value, QueryTriggerInteraction.Ignore);

        //cast at waist level
        Physics.SphereCast(transform.position, 0.35f, Vector3.down, out hitInfo2,
            0.5f, mask.value, QueryTriggerInteraction.Ignore);

        return (hitInfo1.collider != null || hitInfo2.collider != null);

    }

    public void SpeedBurst(float _boostAmount)
    {

        startingClimbSpeed = climbSpeed;
        startingWalkSpeed = walkSpeed;

        climbSpeed += _boostAmount;
        walkSpeed += _boostAmount;

        StartCoroutine("SpeedUp");

    }

    IEnumerator SpeedUp()
    {

        Debug.Log("Speed Boost Happening!");

        for (int i = 0; i < speedBoostTime; i++)
        {

            yield return new WaitForSeconds(1);

        }

        SpeedUpEnd();

    }

    void SpeedUpEnd()
    {


        Debug.Log("Speed Boost Off!");


        climbSpeed = startingClimbSpeed;
        walkSpeed = startingWalkSpeed;


    }

    public void StaminaChange(float _amount)
    {

        currentStamina += _amount;

    }

    public void StaminaBuff(float _time)
    {



    }

    void GrappleShoot()
    {
        // FLIPS THE BOOL FOR PRESS AND RELEASE.  STARTS AS FALSE SO FIRST PRESS WITLL MAKE IT TRUE.
        //isGrappling = !isGrappling;


        if (isGrappling == false)
        {


            grappleGunBehavior.StartGrapple();
            
           
        }

        else
        {


            grappleGunBehavior.StopGrapple();
            

        }
       

    }

    void ReticleUpdate()
    {
        
        Vector2 input = controller.Gameplay.Camera.ReadValue<Vector2>();
        //Vector3 movement = new Vector3(input.x, input.y, 0);
        //Quaternion newRot = new Quaternion(input.x, input.y, 0);
        Vector2 reticleMovement = new Vector2(input.x * reticleSensitivity, input.y * reticleSensitivity);

        reticleMovement.Normalize();

        reticle.GetComponent<Rigidbody2D>().MovePosition(reticleMovement);

        reticle.transform.rotation = cam.gameObject.transform.rotation;

        //reticle.transform.position = reticleStartingPos.position + movement;
        //reticle.transform.rotation = Quaternion.identity;

    }

    void CameraUpdate()
    {

        Vector2 cameraControls = controller.Gameplay.Camera.ReadValue<Vector2>();

        Vector3 localRight = Vector3.Cross(Vector3.up, cameraOffset);
        cameraOffset = Quaternion.AngleAxis(cameraControls.x, Vector3.up)
                        * Quaternion.AngleAxis(cameraControls.y, localRight)
                        * cameraOffset;
        
    }

    void CameraFollow()
    {

        transform.position = Vector3.SmoothDamp(transform.position,
                                                cameraTarget.position + cameraPivot + cameraOffset,
                                                ref velo,
                                                0.5f,
                                                20f,
                                                Time.fixedDeltaTime);
        transform.forward = cameraTarget.position - transform.position;

    }

}
