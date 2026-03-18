using UnityEngine;

public class HandAnimation : MonoBehaviour
{
    public Animator handAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHandAnimation(string animationName)
    {
        if (handAnimator != null)
        {
            handAnimator.Play(animationName);
        }
    }
}
