using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed = 30.0f;
    private float turnSpeed = 30.0f;
    private float horizontalInput;
    private float forwardInput;
    public bool isOnWater = true;
    public float jumpforce = 10;
    public float gravityModifyer;
    public bool hasBoost = false;
    public List<GameObject> Checkpoints = new List<GameObject>();
    public GameObject activeCheckpoint;
    public bool finished;
    public bool hasJumpedOnce = false;

        // Start is called before the first frame update
        void Start()
    {

        Physics.gravity *= gravityModifyer;
        playerRB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);



        if (Input.GetKeyDown(KeyCode.Space) && isOnWater && hasBoost && hasJumpedOnce == false)
        {

            playerRB.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isOnWater = false;
            hasJumpedOnce = true;

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            transform.position = activeCheckpoint.transform.position;
            transform.rotation = activeCheckpoint.transform.rotation;

        }
    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground") && hasBoost == false && finished == false)
        {

            isOnWater = true;
            speed = 30;
            turnSpeed = 30;

        }

        if (collision.gameObject.CompareTag("Ground") && hasBoost == true && finished == false)
        {

            isOnWater = true;
            speed = 50;
            turnSpeed = 30;

        }

        if (!collision.gameObject.CompareTag("Ground") && finished == false)
        {

            isOnWater = false;

        }

        if (collision.gameObject.CompareTag("Terrain") && isOnWater == false && finished == false)
        {

            speed = 1;
            turnSpeed = 1;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {

            isOnWater = true;
            hasJumpedOnce = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Boost"))
        {

            Boost();
            Destroy(other.gameObject);
            StartCoroutine(BoostCountdownRoutine());
            hasBoost = true;

        }

        if (other.CompareTag("Checkpoint"))
        {

            activeCheckpoint = other.gameObject;

        }

        if (other.CompareTag("Finish Line"))
        {

            finished = true;
            speed = 0;
            turnSpeed = 0;

        }

    }

    IEnumerator BoostCountdownRoutine()
    {

        yield return new WaitForSeconds(10);
        speed = 30;
        hasBoost = false;

    }

    private void Boost()
    {

        speed = 50;

    }
}