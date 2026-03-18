using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    private Vector3 spawnPosition;

    public float bulletLife;
    //public float rotation = 0f;
    public float speed;
    private float timer = 0f;
    Camera mCamera;
    private Vector3 playerPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mCamera = Camera.main;
        playerPosition = new Vector3(mCamera.transform.position.x, mCamera.transform.position.y, mCamera.transform.position.z);
        transform.Rotate(90.0f, 0f, 0f, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > bulletLife)
        {
            Destroy(this.gameObject);
        }
        timer += Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed);
    }

    private void OnTriggerEnter3D(Collider collision)
    {
        if (collision.CompareTag("MainCamera"))
        {
            if(mCamera != null)
            {
                //dead
                
            }
        }
    }
}
