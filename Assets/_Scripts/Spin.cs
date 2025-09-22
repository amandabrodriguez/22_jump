using UnityEngine;
using UnityEngine.Analytics;

public class Spin : MonoBehaviour
{
    private float rotationSpeed = 70f;
    private float translateSpeed = 10f;
    private PlayerController _playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerController.GameOver)
        {
            transform.localPosition += Vector3.left * translateSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
