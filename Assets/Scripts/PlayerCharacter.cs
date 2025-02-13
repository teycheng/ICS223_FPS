using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    private int health;
    // Use this for initialization
    void Start () {
        health = 5;
    }
    public void Hit() {
        health -= 1;
        Debug.Log ("Health: " + health);
        if (health == 0) {
            Debug.Break();
        }
    }
}