using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    [SerializeField] private InputActionProperty gripAction;
    [SerializeField] private Hand hand;

    void OnEnable()
    {
        gripAction.action.Enable();
    }

    void OnDisable()
    {
        gripAction.action.Disable();
    }

    void Update()
    {
        if (hand == null) return;

        float grip = gripAction.action.ReadValue<float>();
        hand.SetClosed(grip);
    }
}