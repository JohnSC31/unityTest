using UnityEngine;

public class TeleportationController : MonoBehaviour
{
    public Transform player; // Referencia al jugador (XR Rig o cámaras)
    public Transform WIM1;
    public Transform WIM2;
    public Transform Room1Spawn; // Punto de teletransportación en la habitación 1
    public Transform Room2Spawn; // Punto de teletransportación en la habitación 2
    public Transform WIM1Spawn;
    public Transform WIM2Spawn;

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
        WIM2.position = WIM2Spawn.position;
        WIM2.rotation = WIM2Spawn.rotation;

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
        WIM1.position = WIM1Spawn.position;
        WIM1.rotation = WIM1Spawn.rotation;

        // Actualizar las variables booleanas
        isInRoom1 = false;
        isInRoom2 = true;

        Debug.Log("Teletransportado a la habitación 2.");
    }
}