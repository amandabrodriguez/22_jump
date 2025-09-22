using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    private const string SPEED_F = "Speed_f";
    private const string SPEED_MULTIPLIER_F = "Speed_Multiplier_f";
    private const string JUMP_TRIGGER = "Jump_trig";
    private const string DEATH_B = "Death_b";
    private const string DEATH_TYPE_INT = "DeathType_int";

    private Rigidbody _rb;
    private Animator _animator;
    private float speedMultiplier = 1f;
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    public AudioClip jumpSound, crashSound;
    private AudioSource _audioSource;
    [Range(0, 1)] public float audioVolume = .8f;

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
        _animator = GetComponent<Animator>();
        _animator.SetFloat(SPEED_F, 1); // Set the speed of the running animation
        _audioSource = GetComponent<AudioSource>();
        Physics.gravity = gravityMultiplier * new Vector3(0, -9.81f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        speedMultiplier += Time.deltaTime / 100;
        _animator.SetFloat(SPEED_MULTIPLIER_F, speedMultiplier);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !GameOver)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //F = m * a
            isOnGround = false;
            _animator.SetTrigger(JUMP_TRIGGER);
            dirt.Stop();
            _audioSource.PlayOneShot(jumpSound, audioVolume);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!GameOver)
            {
                isOnGround = true;
                dirt.Play();
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            explosion.Play();
            _animator.SetBool(DEATH_B, true);
            _animator.SetInteger(DEATH_TYPE_INT, Random.Range(1, 3));
            dirt.Stop();
            _audioSource.PlayOneShot(crashSound, audioVolume);
            Invoke(nameof(RestartGame), 1.5f);
            Physics.gravity = Vector3.down * 100f;
        }
    }

    void RestartGame()
    {
        speedMultiplier = 1f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}