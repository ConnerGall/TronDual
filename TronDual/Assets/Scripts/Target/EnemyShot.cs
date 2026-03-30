using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShot : MonoBehaviour
{
    private Vector3 spawnPosition;

    public float bulletLife;
    //public float rotation = 0f;
    public float speed;
    private float timer = 0f;
    Camera mCamera;
    private Vector3 playerPosition;
    private Vector3 moveDirection;

    string currScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mCamera = Camera.main;
        playerPosition = new Vector3(mCamera.transform.position.x, mCamera.transform.position.y, mCamera.transform.position.z);
        moveDirection = (playerPosition - transform.position).normalized;
        transform.Rotate(90.0f, 0f, 0f, Space.World);
        currScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > bulletLife)
        {
            Destroy(this.gameObject);
        }
        timer += Time.deltaTime;

        //transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + moveDirection, speed);
        
        //transform.Translate(speed * Time.deltaTime * playerPosition);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(mCamera != null)
            {
                //dead
                SceneManager.LoadScene(currScene);
            }
        }
    }
}
