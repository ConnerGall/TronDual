using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabHandler : MonoBehaviour
{
    private XRGrabInteractable grab;
    private MeshCollider meshCol;
    private Rigidbody rb;

    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        meshCol = GetComponentInChildren<MeshCollider>();
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        grab.selectEntered.AddListener(OnGrab);
    }

    void OnDisable()
    {
        grab.selectEntered.RemoveListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Unparent from hand
        transform.SetParent(null);

        // Enable mesh collider
        if (meshCol != null)
            meshCol.enabled = true;

        // Re-enable physics
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }
}

