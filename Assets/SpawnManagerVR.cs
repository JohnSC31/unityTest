using UnityEngine;

public class SpawnManagerVR : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public Transform spawnPointRoom;
    public Transform spawnPointWIM;
    public Transform realOrigin; // Centro de la habitación real
    public Transform wimOrigin;  // Centro del WIM
    public float wimScaleFactor = 0.04f;

    public void SpawnObject()
    {
        int randomIndex = Random.Range(0, objectPrefabs.Length);

        // Instanciar en la habitación real
        GameObject objInRoom = Instantiate(objectPrefabs[randomIndex], spawnPointRoom.position, Quaternion.identity);

        // Instanciar en el WIM
        GameObject objInWIM = Instantiate(objectPrefabs[randomIndex], spawnPointWIM.position, Quaternion.identity);
        objInWIM.transform.localScale *= wimScaleFactor;

        // Agregar script que sincronice posición y rotación
        WIMFollower follower = objInWIM.AddComponent<WIMFollower>();
        follower.target = objInRoom.transform;
        follower.realOrigin = realOrigin;
        follower.wimOrigin = wimOrigin;
        follower.scaleFactor = wimScaleFactor;
    }
}
