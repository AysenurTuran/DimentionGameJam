using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform startPoint; // Ba�lang�� noktas� GameObject'i
    public Transform endPoint;   // Biti� noktas� GameObject'i
    public float speed = 2f;     // Hareket h�z�

    public bool calistirr = false;

    private Rigidbody2D rb;
    private Vector3 currentTarget;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentTarget = endPoint.position;
    }

    void FixedUpdate()
    {
        if(calistirr)
        {
            Vector3 direction = (currentTarget - transform.position).normalized;
            rb.velocity = direction * speed;
        }
            
        
       

       
        


    }
    public void Calistir()
    {
        calistirr = true;
    }
}