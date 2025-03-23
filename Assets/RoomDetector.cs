using UnityEngine;

public class RoomDetector : MonoBehaviour
{
    public int roomID; // 1 para habitación 1, 2 para habitación 2

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto entró en un área de habitación
        if (other.CompareTag("Room1Area"))
        {
            roomID = 1; // Habitación 1
        }
        else if (other.CompareTag("Room2Area"))
        {
            roomID = 2; // Habitación 2
        }

        Debug.Log($"El objeto {name} está en la habitación: {roomID}");
    }

    private void OnTriggerExit(Collider other)
    {
        // Verificar si el objeto salió de un área de habitación
        if (other.CompareTag("Room1Area") || other.CompareTag("Room2Area"))
        {
            roomID = 0; // Fuera de las habitaciones
        }

        Debug.Log($"El objeto {name} salió de la habitación: {roomID}");
    }
}