using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class RepeatBackground : MonoBehaviour
{

    private Vector3 startPos;
    private float repeatWidth;

    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        if (startPos.x - transform.position.x > repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
