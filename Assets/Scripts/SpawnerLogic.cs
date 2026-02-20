using UnityEngine;

public class SpawnerLogic : MonoBehaviour
{
    // Список предметов, которые будут падать (положим сюда пончик и камень)
    public GameObject[] items;

    // Время между падениями (секунды)
    public float timeBetweenSpawn = 1.0f;

    void Start()
    {
        // Запускаем бесконечный повтор функции "SpawnObject"
        InvokeRepeating("SpawnObject", 1.0f, timeBetweenSpawn);
    }

    void SpawnObject()
    {
        // 1. Выбираем случайный предмет из твоего списка Items
        int randomIndex = Random.Range(0, items.Length);

        // 2. Генерируем случайное смещение влево и вправо.
        // Попробуй для начала диапазон от -4 до 4.
        float randomOffset = Random.Range(-400f, 400f);

        // 3. Создаем новую позицию: берем X спавнера и ПРИБАВЛЯЕМ смещение
        Vector3 spawnPos = new Vector3(transform.position.x + randomOffset, transform.position.y, 0);

        // 4. Создаем сам объект в этой новой случайной точке
        Instantiate(items[randomIndex], spawnPos, Quaternion.identity);
    }
}