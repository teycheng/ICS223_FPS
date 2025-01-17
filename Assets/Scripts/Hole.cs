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

    void OnCollisionEnter()
    {
        //collision does not work 
        if (collision.gameObject == "Ball")
        {
            Destroy(collision.gameObject);
        }
    }
}
