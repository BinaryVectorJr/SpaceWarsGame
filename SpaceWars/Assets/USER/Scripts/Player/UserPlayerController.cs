using UnityEngine;

/// <summary>
/// Handles player input for movement as well as other gameplay elements (player specific)
/// </summary>

[RequireComponent(typeof(Mirror.NetworkTransform))]
[RequireComponent(typeof(Rigidbody))]

//[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerSettings))]
[RequireComponent(typeof(PlayerModel))]
[RequireComponent(typeof(PlayerMover))]


public class UserPlayerController : Mirror.NetworkBehaviour
{
    public Rigidbody userRigidBody;
    //public PlayerHealth userPlayerHealth;
    public PlayerSettings userPlayerSettings;
    public PlayerModel userPlayerModel;
    public PlayerMover userPlayerMover;

    void OnValidate()
    {

    }

    void Awake()
    {
        //if(userPlayerHealth == null)
        //{
        //    userPlayerHealth = GetComponent<PlayerHealth>();
        //}

        if (userRigidBody == null)
        {
            userRigidBody = GetComponent<Rigidbody>();
        }

        if (userPlayerSettings == null)
        {
            userPlayerSettings = GetComponent<PlayerSettings>();
        }

        if (userPlayerModel == null)
        {
            userPlayerModel = GetComponent<PlayerModel>();
        }

        if (userPlayerMover == null)
        {
            userPlayerMover = GetComponent<PlayerMover>();
        }

    }

    private void Start()
    {
        //Setup the type of player model
        userPlayerModel.SetupPlayerModel(userPlayerSettings.playerObjType);
    }

    public override void OnStartLocalPlayer()
    {
        Camera.main.orthographic = false;
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = new Vector3(0f, 3f, -8f);
        Camera.main.transform.localEulerAngles = new Vector3(10f, 0f, 0f);
    }

    void OnDisable()
    {
        if (isLocalPlayer && Camera.main != null)
        {
            Camera.main.orthographic = true;
            Camera.main.transform.SetParent(null);
            Camera.main.transform.localPosition = new Vector3(0f, 70f, 0f);
            Camera.main.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
        }
    }

    //TODO: Move these to Player Settings file (so that the speed variables are based on the type of player we want to work with)
    [Header("Movement Settings")]
    public float moveSpeed = 8f;
    public float maxTurnSpeed = 1f;

    void FixedUpdate()
    {
        if (!isLocalPlayer)
            return;

        userPlayerMover.Movement();

        //Gun

        //Shoot
        if(Input.GetKey(KeyCode.Mouse0))
        {
            //shoot projectile
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //collision detected but does not show in visuals
        Debug.Log(this.gameObject.transform.name + " hit");
    }
}


