using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WIMTeleportation : MonoBehaviour
{
    public Transform teleportLocation_A;
    public Transform teleportLocation_B;
    public Transform userRig;
    public Transform WIM1;
    public Transform WIM2;
    public Transform WIMPosition1Room1;
    public Transform WIMPosition1Room2;
    public Transform WIMPosition2Room1;
    public Transform WIMPosition2Room2;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if (other.CompareTag("WIM_1"))
        {
            TeleportUser(teleportLocation_A, 1);
        }
        else if (other.CompareTag("WIM_2"))
        {
            TeleportUser(teleportLocation_B, 2);
        }
    }

    void TeleportUser(Transform location, int room)
    {
        userRig.position = location.position;
        userRig.rotation = location.rotation;
        //WIM1.position = room == 1 ? WIMPosition1Room1.position : WIMPosition1Room2.position;
        //WIM2.position = room == 1 ? WIMPosition2Room2.position : WIMPosition2Room2.position;
    }
}
