using UnityEngine;

public class SpawnManagerVR : MonoBehaviour
{
    public GameObject[] objectPrefabs; // Prefabs de los objetos
    public Transform spawnPointRoom; // Punto de spawn en la habitación grande
    public Transform spawnPointWIM1; // Punto de spawn en el WIM de la habitación 1
    public Transform spawnPointWIM2; // Punto de spawn en el WIM de la habitación 2
    public GameObject wimContainer1; // Contenedor de los objetos en el WIM 1
    public GameObject wimContainer2; // Contenedor de los objetos en el WIM 2

    void Start()
    {
        // Inicialización si es necesaria
    }

    public void SpawnObject()
    {

        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject newObjectRoom = Instantiate(objectPrefabs[randomIndex], spawnPointRoom.position, Quaternion.identity);

        // Agregar el RoomDetector al objeto instanciado
        RoomDetector roomDetectorRoom = newObjectRoom.AddComponent<RoomDetector>();

        // Esperar un frame para que el RoomDetector detecte la habitación
        StartCoroutine(WaitAndCreateWIMObject(newObjectRoom, randomIndex));
    }

    private System.Collections.IEnumerator WaitAndCreateWIMObject(GameObject roomObject, int prefabIndex)
    {
        // Esperar un frame
        yield return null;

        // Obtener el RoomDetector del objeto en la habitación grande
        RoomDetector roomDetector = roomObject.GetComponent<RoomDetector>();

        // Verificar el roomID y crear la réplica en el WIM correspondiente
        if (roomDetector.roomID == 1)
        {
            CreateWIMObject(roomObject, prefabIndex, spawnPointWIM1, wimContainer1);
        }
        else if (roomDetector.roomID == 2)
        {
            CreateWIMObject(roomObject, prefabIndex, spawnPointWIM2, wimContainer2);
        }
    }

private void CreateWIMObject(GameObject roomObject, int prefabIndex, Transform spawnPointWIM, GameObject wimContainer)
{
    Debug.Log($"Creando objeto en el WIM en posición: {spawnPointWIM.position}");

    // Instanciar la réplica en el WIM
    GameObject newObjectWIM = Instantiate(objectPrefabs[prefabIndex], spawnPointWIM.position, Quaternion.identity);
    newObjectWIM.transform.localScale *= 0.04f; // Escalar para el WIM
    newObjectWIM.transform.parent = wimContainer.transform; // Asignar al contenedor del WIM

    // Agregar el RoomDetector a la réplica en el WIM
    RoomDetector roomDetectorWIM = newObjectWIM.AddComponent<RoomDetector>();
    roomDetectorWIM.roomID = roomObject.GetComponent<RoomDetector>().roomID; // Asignar el mismo RoomID

    // Sincronizar los objetos
    SynchronizeObjects(roomObject, newObjectWIM);
}

    private void SynchronizeObjects(GameObject roomObject, GameObject wimObject)
    {
        // Asignar los pares para sincronización
        roomObject.GetComponent<ObjectSync>().SetPair(wimObject);
        wimObject.GetComponent<ObjectSync>().SetPair(roomObject);
    }
}