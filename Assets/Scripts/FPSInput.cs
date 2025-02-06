using UnityEngine;

public class FPSInput : MonoBehaviour
{
    private float gravity = -9.8f;
    private float speed = 9.0f;
    [SerializeField] CharacterController charController;
    public float verticalInput;
    public float horizontalInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizInput, 0, vertInput);
        // Clamp magnitude to limit diagonal movement
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        movement.y = gravity;
        // take speed into account
        movement *= speed;
        // make movement processor independent
        movement *= Time.deltaTime;
        // Convert local to global coordinates
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }

}
