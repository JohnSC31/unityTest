using UnityEngine;
using UnityEngine.UI;

public class SpawnManagerVR : MonoBehaviour
{
    public GameObject[] objectPrefabs; 
    public Transform spawnPointRoom;
    public Transform spawnPointWIM;

    void Start()
    {
        
    }

    public void SpawnObject()
    {
        int randomIndex = Random.Range(0, objectPrefabs.Length);

        // Instanciar en la habitación
        GameObject objInRoom = Instantiate(objectPrefabs[randomIndex], spawnPointRoom.position, Quaternion.identity);

        // Instanciar en el WIM
        GameObject objInWIM = Instantiate(objectPrefabs[randomIndex], spawnPointWIM.position, Quaternion.identity);

        // (Opcional) Escalar el objeto del WIM si es necesario
        objInWIM.transform.localScale *= 0.04f;  // ajusta según tu escala del WIM
    }
}
