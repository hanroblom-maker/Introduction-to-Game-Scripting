using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private GameManager gameManager;
    public float moveSpeed = 5f;
    private Transform playerTarget;
    private Vector3 startPosition;
    private bool canMove = true;

    private void Start()
    {
        startPosition = transform.position;
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        Movement();
    }
    void Movement() // Movement Controller
    {
        if (!canMove)
        {
            return;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0);

        transform.position += movement * moveSpeed * Time.deltaTime;
    }

    public void StopMovement()
    {
        canMove = false;
    }

    void TakeDamage()
    {
        Debug.Log("Player took Damage");

        gameManager.RemoveHealth();

        transform.position = startPosition;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            Debug.Log("Collectable Collected");

            gameManager.AddScore();

            Destroy(other.gameObject);
        }

        if (other.CompareTag("Hazard"))
        {
            TakeDamage();
        }
    }
    private void LateUpdate()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        Camera.main.transform.position =
            new Vector3(transform.position.x, transform.position.y, -10f);
    }
    //private void Start()
    //{
    //    startPosition = transform.position;

    //    gameManager = FindObjectOfType<GameManager>();

    //    playerTarget = transform;

    //    followOffset = (Vector3)cameraOffset;
    //    followOffset.z = Camera.main.transform.position.z - playerTarget.position.z;
    //}


    //private void LateUpdate()
    //{
    //    CameraFollow();
    //}

    //// Sourced from: "Controlling Unity Camera Behavior - 2019.3", Unity Learn (https://learn.unity.com/tutorial/controlling-unity-camera-behaviour-2019-3), adapted by Hanro Blom.
    //private void CameraFollow()
    //{
    //    Camera.main.transform.position =
    //        Vector3.MoveTowards(
    //            Camera.main.transform.position,
    //            playerTarget.position + followOffset,
    //            cameraFollowSpeed * Time.deltaTime);
    //}


    // I found it, had trouble implementing
}
