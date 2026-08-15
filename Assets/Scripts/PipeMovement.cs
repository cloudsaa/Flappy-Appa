using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    bool gameStarted = false;

    void Update()
    {
        if (gameStarted)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    public void StartMoving()
    {
        gameStarted = true;
    }

    public void StopMoving()
    {
        gameStarted = false;
    }
}