using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private float startDelay = 1;
    private float repeatDelay = 2;
    private PlayerController _playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatDelay);
    }

    void SpawnObstacle()
    {
        if (_playerController.GameOver) return;
        int prefabIndex = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[prefabIndex], transform.position, obstaclePrefabs[prefabIndex].transform.rotation);
    }
}
