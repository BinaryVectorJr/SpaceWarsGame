using UnityEngine;

/// <summary>
/// Handles player input for movement as well as other gameplay elements (player specific)
/// </summary>

[RequireComponent(typeof(Mirror.NetworkTransform))]
[RequireComponent(typeof(Rigidbody))]

//[RequireComponent(typeof(PlayerHealth))]
//[RequireComponent(typeof(PlayerSettings))]
//[RequireComponent(typeof(PlayerModel))]



public class UserPlayerController : Mirror.NetworkBehaviour
{
    //public PlayerHealth userPlayerHealth;
    public PlayerSettings userPlayerSettings;
    public PlayerModel userPlayerModel;

    void OnValidate()
    {

    }

    void Awake()
    {
        //if(userPlayerHealth == null)
        //{
        //    userPlayerHealth = GetComponent<PlayerHealth>();
        //}

        if (userPlayerSettings == null)
        {
            userPlayerSettings = GetComponent<PlayerSettings>();
        }

        if (userPlayerModel == null)
        {
            userPlayerModel = GetComponent<PlayerModel>();
        }

    }

    public override void OnStartLocalPlayer()
    {
        Camera.main.orthographic = false;
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = new Vector3(0f, 0f, 0f);
        Camera.main.transform.localEulerAngles = new Vector3(10f, 0f, 0f);


        //Setup the type of player model
        userPlayerModel.setupPlayerModel(userPlayerSettings.playerObjType);

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

    [Header("Movement Settings")]
    public float moveSpeed = 8f;
    public float maxTurnSpeed = 1f;

    void FixedUpdate()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Vector3.up, -maxTurnSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.up, maxTurnSpeed);
        }
    }
}


