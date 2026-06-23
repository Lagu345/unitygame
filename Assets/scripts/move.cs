using UnityEngine;


public class move : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 10f;
    public int Speed = 2;

    private bool onFloor = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * Speed;

        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward *Time.deltaTime * Speed;
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
           transform.position -= transform.right * Time.deltaTime * Speed;
        }
        if ((Input.GetKeyDown(KeyCode.B) && onFloor))
        {
            // transform.position += transform.up  * Time.deltaTime * Speed;
            rb.AddForce(0, force, 0);
            

        } 
        
        

        
    }



    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("oncollision enter : " + collision.gameObject.tag);
        if (collision.gameObject.tag == "floor")
            onFloor = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("oncollision exit : " + collision.gameObject.tag);
        if (collision.gameObject.tag == "floor")
            onFloor = false;
    }
}
