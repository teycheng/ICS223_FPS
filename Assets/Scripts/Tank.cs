using UnityEngine;

public class Tank : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody rb;
    public float verticalInput;

    public Transform frontLeftWheel;
    public Transform frontRightWheel;
    public Transform backLeftWheel;
    public Transform backRightWheel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");

    }

    void FixedUpdate()
    {
        Vector3 movement = transform.forward * verticalInput * speed;
        rb.linearVelocity =  new Vector3(movement.x, rb.linearVelocity.y, movement.z);
    }

    void wheelRotation()
{
    float wheelRotation = speed * Time.deltaTime * Input.GetAxis("Vertical");
    
    frontLeftWheel.Rotate(wheelRotation, 0f, 0f);
    frontRightWheel.Rotate(wheelRotation, 0f, 0f);
}

}
