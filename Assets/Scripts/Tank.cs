using UnityEngine;

public class Tank : MonoBehaviour
{
    private float speed = 2f;
    private Rigidbody rb;
    public float verticalInput;

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
        Vector3 movement = Vector3.forward * verticalInput * speed;
        transform.Translate(movement);
    }


}
