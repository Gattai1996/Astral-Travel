using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public Material redMaterial;

    private Rigidbody playerRigidBody;
    private float movementForce;
    private float movementSpeed = 10f;
    private bool gameOver;
    private Animator animator;
    private GameObject starsParticles, starsRedParticles;

    private void Awake()
    {
        Instance = this;
        playerRigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        starsParticles = Resources.Load("Stars Particle System") as GameObject;
        starsRedParticles = Resources.Load("Stars Red Particle System") as GameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Platform>() != null)
        {
            animator.SetTrigger("Jump");
            Vector3 playerVelocity = playerRigidBody.velocity;
            playerVelocity.y = collision.gameObject.GetComponent<Platform>().jumpForce;
            playerRigidBody.velocity = playerVelocity;
            Instantiate(starsParticles, new Vector3(transform.position.x, transform.position.y + 0.6f, 0), Quaternion.identity, transform);
            collision.gameObject.GetComponent<AudioSource>().Play();
        }
        else if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            StartCoroutine(RestartGame());
        }
    }

    private void Update()
    {
        movementForce = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (!gameOver)
        {
            Vector3 playerVelocity = playerRigidBody.velocity;
            playerVelocity.x = movementForce * movementSpeed;
            playerRigidBody.velocity = playerVelocity;

            if (transform.position.y < Camera.main.transform.position.y - 10)
            {
                StartCoroutine(RestartGame());
            }
        }
    }

    IEnumerator RestartGame()
    {
        gameOver = true;
        transform.Find("Cube").GetComponent<Renderer>().material = redMaterial;
        Instantiate(starsRedParticles, new Vector3(transform.position.x, transform.position.y + 0.6f, 0), Quaternion.identity, transform);
        yield return new WaitForSeconds(1f);
        GameManager.Instance.SaveHighScore();
        SceneManager.LoadScene("Game Over Scene");
    }
}
