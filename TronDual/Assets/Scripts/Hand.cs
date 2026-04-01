using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    private Animator animator;
    private float closedTarget;
    private float closedCurrent;
    private const string AnimatorClosedParam = "Closed";

    [SerializeField]
    private float speed = 10f;
    /// <summary>
    /// Speed at which the hand closes/opens.
    /// </summary>
    public float Speed
    {
        get => speed;
        set => speed = Mathf.Max(0f, value);
    }

    /// <summary>
    /// Sets the target closed value for the hand (0 = open, 1 = closed).
    /// </summary>
    /// <param name="value">Target closed value (0 to 1).</param>
    public void SetClosed(float value)
    {
        closedTarget = Mathf.Clamp01(value);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        closedCurrent = closedTarget;
        animator.SetFloat(AnimatorClosedParam, closedCurrent);
    }

    private void Update()
    {
        AnimateHand();
    }

    private void AnimateHand()
    {
        if (!Mathf.Approximately(closedCurrent, closedTarget))
        {
            closedCurrent = Mathf.MoveTowards(closedCurrent, closedTarget, Time.deltaTime * speed);
            animator.SetFloat(AnimatorClosedParam, closedCurrent);
        }
    }
}
