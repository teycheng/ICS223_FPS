using UnityEngine;

public class Hole : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //collision does not work 
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
        }
    }
}
