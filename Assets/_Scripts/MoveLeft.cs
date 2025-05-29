using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    public float speed = 10f;

    void Start()
    {

    }


    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.left);
    }
}
