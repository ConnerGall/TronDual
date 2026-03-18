using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    private Vector3 spawnPosition;

    public float bulletLife = 1f;
    //public float rotation = 0f;
    public float speed = 1f;
    private float timer = 0f;
    [SerializeField] GameObject player;
    private Vector3 playerPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPosition = new Vector3(player.transform.parent.position.x, player.transform.parent.position.y + 1, player.transform.parent.position.z);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHitBox"))
        {
            if(player != null)
            {
                //DIE 
            }
        }
    }
}
