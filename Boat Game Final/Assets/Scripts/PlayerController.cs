using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private float speed = 30.0f;
    private float turnSpeed = 30.0f;
    private float horizontalInput;
    private float forwardInput;
    public bool isOnGround = true;
    public float jumpforce = 10;
    public float gravityModifyer;
    public bool hasBoost = false;

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



        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && hasBoost)
        {

            playerRB.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isOnGround = false;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {

            isOnGround = true;

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