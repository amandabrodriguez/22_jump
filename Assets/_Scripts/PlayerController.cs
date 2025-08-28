using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{

    private Rigidbody _rb;
    public float jumpForce = 10f;
    public float gravityMultiplier = 2;
    public bool isOnGround = true;
    private bool gameOver = false;

    public bool GameOver
    {
        get => gameOver;
        set
        {
            if (gameOver) return;
            gameOver = value;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !GameOver)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //F = m * a
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }
}