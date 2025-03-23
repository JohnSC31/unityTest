using UnityEngine;

public class ObjectSync : MonoBehaviour
{
    private GameObject pairedObject; // Objeto con el que está sincronizado

    public void SetPair(GameObject pair)
    {
        pairedObject = pair;
    }

    private void Update()
    {
        if (pairedObject != null)
        {
            // Sincronizar posición y rotación
            pairedObject.transform.position = transform.position;
            pairedObject.transform.rotation = transform.rotation;
        }
    }
}