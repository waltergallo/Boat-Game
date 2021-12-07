using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed = 0;
    public float turnSpeed = 0;
    private float horizontalInput;
    public float forwardInput;
    public bool isOnWater = true;
    public float jumpforce = 10;
    public float gravityModifyer;
    public bool hasBoost = false;
    public List<GameObject> Checkpoints = new List<GameObject>();
    public GameObject activeCheckpoint;
    public bool finished = false;
    public bool hasJumpedOnce = false;
    private GameManager gameManager;
    public GameObject gameManagerObj;
    public float movingSpeed;
    public int forward;
    public float actualSpeed;
    public float tempo;
    public ParticleSystem explosionParticle;
    public GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Physics.gravity *= gravityModifyer;
        playerRB = GetComponent<Rigidbody>();
        forwardInput = Input.GetAxis("Vertical");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) && finished == false)
        {

            forwardInput = Input.GetAxis("Vertical");

        }

        if (forwardInput > 0)
        {

            movingSpeed = 0;
            forward = 1;

        }

        if (forwardInput < 0)
        {

            movingSpeed = speed - 5;
            forward = 0;

        }

        if (finished == false)
        {

            horizontalInput = Input.GetAxis("Horizontal");

        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W) && forward == 1 && finished == false)
        {


            StartCoroutine(SlowDown1());


        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) && finished == false)
        {

            forwardInput = Input.GetAxis("Vertical");

        }


        transform.Translate(Vector3.right * Time.deltaTime * (speed - movingSpeed - actualSpeed) * forwardInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && isOnWater && hasBoost && hasJumpedOnce == false)
        {

            playerRB.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isOnWater = false;
            hasJumpedOnce = true;
            explosionParticle.Play();

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
            Speed();
            TurnSpeed();

        }

        if (collision.gameObject.CompareTag("Ground") && hasBoost == true && finished == false)
        {

            isOnWater = true;
            Boost();
            TurnSpeed();

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

        }

    }

    IEnumerator BoostCountdownRoutine()
    {

        yield return new WaitForSeconds(10);
        hasBoost = false;

    }

    IEnumerator SlowDown1()
    {

        if (!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.W))
        {
            tempo = speed / 10;
            forwardInput = 1;
            actualSpeed += tempo;
            yield return new WaitForSeconds(0.18f);
            StartCoroutine(SlowDown2());
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.W))
        {
            
            forwardInput = Input.GetAxis("Vertical");
            actualSpeed = 0; yield break;

        }

    }

    IEnumerator SlowDown2()
    {

        if (!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.W))
        {
            tempo = speed / 10;
            actualSpeed += tempo;
            yield return new WaitForSeconds(0.18f);
            StartCoroutine(SlowDown3());
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.W))
        {
            
            forwardInput = Input.GetAxis("Vertical");
            actualSpeed = 0; yield break;

        }

    }

    IEnumerator SlowDown3()
    {

        if (!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.W))
        {
            tempo = speed / 10;
            actualSpeed += tempo;
            yield return new WaitForSeconds(0.18f);
            StartCoroutine(SlowDown4());
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.W))
        {
            
            forwardInput = Input.GetAxis("Vertical");
            actualSpeed = 0; yield break;

        }

    }

    IEnumerator SlowDown4()
    {

        if (!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.W))
        {
            tempo = speed / 10;
            actualSpeed += tempo;
            yield return new WaitForSeconds(0.18f);
            StartCoroutine(SlowDown5());
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.W))
        {
            
            forwardInput = Input.GetAxis("Vertical");
            actualSpeed = 0; yield break;

        }

    }

    IEnumerator SlowDown5()
    {

        if (!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.W))
        {
            tempo = speed / 10;
            actualSpeed += tempo;
            yield return new WaitForSeconds(0.18f);
            StartCoroutine(SlowDown6());
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.W))
        {
            
            forwardInput = Input.GetAxis("Vertical");
            actualSpeed = 0; yield break;

        }

    }

    IEnumerator SlowDown6()
    {

        if (!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.W))
        {
            tempo = speed / 10;
            actualSpeed += tempo;
            yield return new WaitForSeconds(0.18f);
            StartCoroutine(SlowDown7());
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.W))
        {
            
            forwardInput = Input.GetAxis("Vertical");
            actualSpeed = 0; yield break;

        }

    }

    IEnumerator SlowDown7()
    {

        if (!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.W))
        {
            tempo = speed / 10;
            actualSpeed += tempo;
            yield return new WaitForSeconds(0.18f);
            StartCoroutine(SlowDown8());
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.W))
        {
            
            forwardInput = Input.GetAxis("Vertical");
            actualSpeed = 0; yield break;

        }

    }

    IEnumerator SlowDown8()
    {

        if (!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.W))
        {
            tempo = speed / 10;
            actualSpeed += tempo;
            yield return new WaitForSeconds(0.18f);
            StartCoroutine(SlowDown9());
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.W))
        {
            
            forwardInput = Input.GetAxis("Vertical");
            actualSpeed = 0; yield break;

        }

    }

    IEnumerator SlowDown9()
    {

        if (!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.W))
        {
            tempo = speed / 10;
            actualSpeed += tempo;
            yield return new WaitForSeconds(0.18f);
            StartCoroutine(SlowDown10());
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.W))
        {
            
            forwardInput = Input.GetAxis("Vertical");
            actualSpeed = 0; yield break; 

        }

    }

    IEnumerator SlowDown10()
    {

        if (!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.W))
        {
            tempo = speed / 10;
            actualSpeed += tempo;
            yield return new WaitForSeconds(0);
            forwardInput = Input.GetAxis("Vertical");
            actualSpeed = 0;
        }

    }

    private void Boost()
    {

        speed = 50;

    }

    public void Speed()
    {

        if (gameManager.gameMode == 0)
        {

            speed = 0;

        }

        else if (gameManager.gameMode == 3)
        {

            speed = 35;

        }

        else if (gameManager.gameMode == 2)
        {

            speed = 30;

        }

        else if (gameManager.gameMode == 1)
        {

            speed = 25;

        }

    }

    public void TurnSpeed()
    {

        if (gameManager.gameMode == 0)
        {

            turnSpeed = 0;

        }

        else if (gameManager.gameMode == 3)
        {

            turnSpeed = 25;

        }

        else if (gameManager.gameMode == 2)
        {

            turnSpeed = 35;

        }

        else if (gameManager.gameMode == 1)
        {

            turnSpeed = 30;

        }

    }

    public void Reset()
    {

        activeCheckpoint = spawnPoint;
        transform.position = spawnPoint.transform.position;
        transform.rotation = spawnPoint.transform.rotation;

    }
}