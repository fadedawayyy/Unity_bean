using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;    // Какой предмет спавним
    public float spawnInterval;      // Индивидуальная задержка
    public float minX, maxX;         // Границы по горизонтали

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
        Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0);
        Instantiate(itemPrefab, spawnPos, Quaternion.identity);
    }
}