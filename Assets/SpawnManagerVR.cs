using UnityEngine;
using UnityEngine.UI;

public class SpawnManagerVR : MonoBehaviour
{
    public GameObject[] objectPrefabs; 
    // public Transform spawnPointWIM; Setear cuando se tenga el WIM
    public Transform spawnPointRoom;

    void Start()
    {

    }

    public void SpawnObject()
    {
        int randomIndex = Random.Range(0, objectPrefabs.Length);
        Instantiate(objectPrefabs[randomIndex], spawnPointRoom.position, Quaternion.identity);
    }
}

