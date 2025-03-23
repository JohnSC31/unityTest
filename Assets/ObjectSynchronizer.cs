using UnityEngine;

public class ObjectSynchronizer : MonoBehaviour
{
    public GameObject wimRoom; // Referencia al WIM de la habitación
    public int roomID; // ID de la habitación

    // Método para crear un objeto en la habitación grande y su réplica en el WIM
    public void CreateObjectInRoom(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        // Crear el objeto en la habitación grande
        GameObject newObject = Instantiate(prefab, position, rotation);
        newObject.GetComponent<RoomDetector>().roomID = roomID;

        // Crear la réplica en el WIM
        GameObject wimObject = Instantiate(prefab, position, rotation);
        wimObject.transform.localScale *= 0.1f; // Escalar para el WIM
        wimObject.transform.parent = wimRoom.transform; // Asignar al WIM
        wimObject.GetComponent<RoomDetector>().roomID = roomID;

        // Sincronizar los objetos (opcional, si necesitas que los cambios se reflejen en tiempo real)
        SynchronizeObjects(newObject, wimObject);
    }

    // Método para sincronizar cambios entre los objetos
    private void SynchronizeObjects(GameObject roomObject, GameObject wimObject)
    {
        // Aquí puedes agregar lógica para sincronizar transformaciones, colores, etc.
        // Por ejemplo, si el objeto en la habitación grande se mueve, el WIM también debe moverse.
        roomObject.GetComponent<ObjectSync>().SetPair(wimObject);
        wimObject.GetComponent<ObjectSync>().SetPair(roomObject);
    }
}