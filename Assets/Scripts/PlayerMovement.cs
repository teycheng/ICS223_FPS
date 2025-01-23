using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private float speed = 15f;
    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical"); 

        // // Create a direction vector based on input
        // Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        // // Move the player
        // transform.Translate(movement * speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        rb.linearVelocity = movement * speed * 100 * Time.deltaTime;
        //rb.AddForce(movement*25);
    }
}
