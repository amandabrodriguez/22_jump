using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    public float speed = 10f;
    private PlayerController _playerController;

    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void Update()
    {
        if (_playerController.GameOver) return;
        transform.Translate(speed * Time.deltaTime * Vector3.left);
    }
}
