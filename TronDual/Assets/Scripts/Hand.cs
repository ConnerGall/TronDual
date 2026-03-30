using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    Animator animator;
    private float closedTarget;
    private float closedCurrent;
    public float speed;
    private string animatorClosedParam = "Closed";

    internal void SetClosed(float v)
    {
        closedTarget = v;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
    }

    void AnimateHand()
    {
        if (closedCurrent != closedTarget)
        {
            closedCurrent = Mathf.MoveTowards(closedCurrent, closedTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorClosedParam, closedCurrent);

        }
    }
}
