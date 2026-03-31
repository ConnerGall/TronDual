using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    [SerializeField] private InputActionProperty gripAction;
    [SerializeField] private InputActionProperty triggerAction;
    [SerializeField] private Hand hand;

    void OnEnable()
    {
        gripAction.action.Enable();
        triggerAction.action.Enable();
    }

    void OnDisable()
    {
        gripAction.action.Disable();
        triggerAction.action.Disable();
    }

    void Update()
    {
        float grip = gripAction.action.ReadValue<float>();
        float trigger = triggerAction.action.ReadValue<float>();
        float closed = Mathf.Max(grip, trigger);
        hand.SetClosed(closed);
    }
}