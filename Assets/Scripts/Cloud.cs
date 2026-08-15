using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed = 1f;
    public float respawnX = 10f;
    public float minY = -1f;
    public float maxY = 4f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -10f)
        {
            transform.position = new Vector3(
                respawnX,
                Random.Range(minY, maxY),
                transform.position.z
            );
        }
    }
}