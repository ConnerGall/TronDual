using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float frequency = 2f;
    public float magnitude = 7.5f;
    public float offset = 0f;
    private Vector3 spawnPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = spawnPosition + transform.right * Mathf.Sin(Time.time * frequency + offset) * magnitude;
    }
}
