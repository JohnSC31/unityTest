using UnityEngine;
using UnityEngine.UI;

public class SpawnManagerVR : MonoBehaviour
{
    public GameObject[] objectPrefabs; 
    // public Transform spawnPointWIM; Setear cuando se tenga el WIM
    public Transform spawnPointRoom;

    void Start()
    {
        // Inicialización si es necesaria
    }

    public void SpawnObject()
    {
        // Seleccionar un prefab aleatorio
        int randomIndex = Random.Range(0, objectPrefabs.Length);

        // Instanciar el objeto y capturar la referencia
        GameObject newObject = Instantiate(objectPrefabs[randomIndex], spawnPointRoom.position, Quaternion.identity);

        // Agregar el RoomDetector al objeto instanciado
        RoomDetector roomDetector = newObject.AddComponent<RoomDetector>();
    }
}