using UnityEngine;

public class TeleportationController : MonoBehaviour
{
    public Transform player; // Referencia al jugador (XR Rig o cámaras)
    public Transform Room1Spawn; // Punto de teletransportación en la habitación 1
    public Transform Room2Spawn; // Punto de teletransportación en la habitación 2

    // Variables booleanas para verificar en qué habitación está el jugador
    public bool isInRoom1 = false;
    public bool isInRoom2 = false;

    public void TeleportToRoom1()
    {
        // Si ya está en la habitación 1, no hacer nada
        if (isInRoom1)
        {
            Debug.Log("Ya estás en la habitación 1.");
            return;
        }

        // Teletransportar al jugador a la habitación 1
        player.position = Room1Spawn.position;

        // Actualizar las variables booleanas
        isInRoom1 = true;
        isInRoom2 = false;

        Debug.Log("Teletransportado a la habitación 1.");
    }

    public void TeleportToRoom2()
    {
        // Si ya está en la habitación 2, no hacer nada
        if (isInRoom2)
        {
            Debug.Log("Ya estás en la habitación 2.");
            return;
        }

        // Teletransportar al jugador a la habitación 2
        player.position = Room2Spawn.position;

        // Actualizar las variables booleanas
        isInRoom1 = false;
        isInRoom2 = true;

        Debug.Log("Teletransportado a la habitación 2.");
    }
}