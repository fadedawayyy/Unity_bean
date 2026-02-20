using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    void Update()
    {
        // Если предмет упал ниже -10 единиц (улетел за экран)
        if (transform.position.y < -10f)
        {
            Destroy(gameObject); // Удаляем его из памяти
        }
    }
}