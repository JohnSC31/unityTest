using UnityEngine;

public class WIMFollower : MonoBehaviour
{
    public Transform target;           // Objeto real
    public Transform realOrigin;       // Centro del mundo real
    public Transform wimOrigin;        // Centro del WIM
    public float scaleFactor = 0.04f;  // Escala del WIM

    void Update()
    {
        /*if (target != null && realOrigin != null && wimOrigin != null)
        {
            // 1. Obtener el offset desde el centro real
            Vector3 offset = target.position - realOrigin.position;

            // 2. Aplicar rotación del WIM al offset
            Vector3 rotatedOffset = wimOrigin.rotation * offset;

            // 3. Aplicar la posición escalada
            transform.position = wimOrigin.position + rotatedOffset * scaleFactor;

            // 4. Aplicar también la rotación combinada (rotación relativa)
            transform.rotation = wimOrigin.rotation * target.rotation;
        }*/
        if (target != null && realOrigin != null && wimOrigin != null)
        {
            // 1. Obtener la posición relativa en el WIM (en relación con su centro)
            Vector3 offsetInWIM = transform.position - wimOrigin.position;

            // 2. Escalar la posición relativa al tamaño real
            Vector3 offsetInReal = offsetInWIM / scaleFactor;

            // 3. Aplicar la nueva posición al objeto real
            target.position = realOrigin.position + offsetInReal;

            // 4. Sincronizar también la rotación
            target.rotation = transform.rotation;
        }
    }
}
