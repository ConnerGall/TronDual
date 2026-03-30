using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class DiscBehavior : MonoBehaviour
{
    public float spinSpeed = 800f;
    public float stability = 5f;
    public float returnForce = 20f;
    public Transform player;
    public ChangeLevel change;

    Rigidbody rb;
    XRGrabInteractable grab;

    bool returning = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grab = GetComponent<XRGrabInteractable>();

        grab.selectEntered.AddListener(OnGrab);
        grab.selectExited.AddListener(OnRelease);
    }

    void Start()
    {
        if (player == null)
            player = Camera.main.transform;
        if (change == null)
            change = Object.FindFirstObjectByType<ChangeLevel>();
    }

    void FixedUpdate()
    {
        if (!grab.isSelected)
        {
            StabilizeDisc();

            if (returning)
            {
                Vector3 dir = (player.position - transform.position).normalized;
                rb.AddForce(dir * returnForce);
            }
        }
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        returning = false;

        rb.constraints = RigidbodyConstraints.None;
        rb.angularVelocity = Vector3.zero;
    }

    void OnRelease(SelectExitEventArgs args)
    {


        rb.constraints = RigidbodyConstraints.FreezeRotationX |
                     RigidbodyConstraints.FreezeRotationZ;

        Vector3 forward = player.forward;
        Vector3 velocity = rb.linearVelocity;

        float speed = velocity.magnitude;

        rb.linearVelocity = forward * speed;

        rb.angularVelocity = transform.forward * spinSpeed;
    }

    void StabilizeDisc()
    {
        if (rb.angularVelocity.sqrMagnitude < 0.1f) return;

        Quaternion targetRotation =
            Quaternion.LookRotation(rb.angularVelocity.normalized, Vector3.up) *
            Quaternion.Euler(-90f, 180f, 0f);

        rb.MoveRotation(
            Quaternion.Slerp(rb.rotation, targetRotation, stability * Time.fixedDeltaTime)
        );
    }

    public void StartReturn()
    {
        returning = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")){
            change.incrementDestroyed();
        }
    }
}
