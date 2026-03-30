using UnityEngine;

public class TargetShoot : MonoBehaviour
{
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;
    public float firingRate = 1f; //less = more shots, more = less shots
    private GameObject spawnedBullet;
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= firingRate)
        {
            Fire();
            timer = 0f;
        }
    }

    private void Fire()
    {
        if(bullet)
        {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<EnemyShot>().speed = speed;
            spawnedBullet.GetComponent<EnemyShot>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }
}
