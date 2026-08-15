using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject pipePrefab;

    [SerializeField]
    float spawnInterval = 2f;

    [SerializeField]
    float spawnX = 10f;

    [SerializeField]
    float minY = -2f;

    [SerializeField]
    float maxY = 2f;

    public void StartSpawning()
    {
        InvokeRepeating(nameof(SpawnPipe), 0f, spawnInterval);
    }

    public void StopSpawning()
    {
        CancelInvoke(nameof(SpawnPipe));
    }

    void SpawnPipe()
    {
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPosition = new Vector3(
            spawnX,
            randomY,
            0f
        );

        GameObject newPipe = Instantiate(
            pipePrefab,
            spawnPosition,
            Quaternion.identity
        );

        newPipe.GetComponent<PipeMovement>().StartMoving();
    }
}