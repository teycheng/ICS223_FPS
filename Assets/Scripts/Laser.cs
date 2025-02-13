using UnityEngine;

public class Laser : MonoBehaviour {
    public float speed = 6f;
    private float toNewtons = 100;
    [SerializeField] private Rigidbody rb;

    // Update is called once per frame
    void FixedUpdate () {
        Vector3 movement = transform.forward * Time.deltaTime * speed * toNewtons;
        rb.linearVelocity = movement;
    }
    void OnTriggerEnter(Collider other) {
        PlayerCharacter player = other.GetComponent<PlayerCharacter> ();
        if (player != null) {
            player.Hit ();
        }
        Destroy (this.gameObject);
    }
}

