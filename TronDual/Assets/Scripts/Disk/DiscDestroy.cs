using UnityEngine;

public class DiscDestroy : MonoBehaviour
{
    int count = 0;
    public DiscSpawn disc;
    //public DiscBehavior discBehavior;
    private Transform player;   
    public float returnSpeed = 4f;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = Camera.main.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            count++;
        }
        //Debug.Log(count);
        if (count%2 == 0)
        {
            ReturnToPlayer();
            //discBehavior.StartReturn();
        }
        if (count >= 10)
        {
            Destroy(gameObject);
            if (disc != null)
            {
                disc.DiscCount--;
            }
            
            Debug.Log("Destroyed");
        }
    }

    void ReturnToPlayer()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;
         rb.linearVelocity = direction * returnSpeed;
        //Vector3 dir = (player.position - transform.position).normalized;
        //rb.AddForce(dir * returnSpeed);
    }



    // Update is called once per frame
    void Update()
    {
       
    }
}
