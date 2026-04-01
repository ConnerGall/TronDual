using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class UseDifferentHands : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform leftAttach;
    public Transform rightAttach;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        var interactor = args.interactorObject;

        // Check if it's left or right hand
        if (interactor.transform.name.ToLower().Contains("left"))
        {
            grabInteractable.attachTransform = leftAttach;
        }
        else
        {
            grabInteractable.attachTransform = rightAttach;
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // Optional: reset attach transform
        grabInteractable.attachTransform = null;
    }
}
