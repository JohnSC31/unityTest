using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WIMTeleport1 : MonoBehaviour
{
    public TeleportationController teleportController;
    public bool isRoom1WIM; // Define si este WIM corresponde a la habitación 1 o 2

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    private void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (isRoom1WIM)
        {
            teleportController.TeleportToRoom1();
        }
        else
        {
            teleportController.TeleportToRoom2();
        }
    }
}