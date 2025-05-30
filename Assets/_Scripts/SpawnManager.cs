using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private float startDelay = 1;
    private float repeatDelay = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatDelay);
    }

    void SpawnObstacle()
    {
        int prefabIndex = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[prefabIndex], transform.position, obstaclePrefabs[prefabIndex].transform.rotation);
    }
}
