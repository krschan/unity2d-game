using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    int jumpCount = 0;
    float movement = 0;
    [SerializeField] float jumpSpeed = 5.0f;
    [SerializeField] float movementSpeed = 0.1f;

    void Start() {
        
    }

    void Update() {
        movement = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2) {
            jumpCount++;
            Jump();
        }
    }

    void FixedUpdate() {
        if (movement == 0) {
            GetComponent<Animator>().SetBool("run", false);
        } else {
            GetComponent<Animator>().SetBool("run", true);
        }

        if (movement > 0) {
            Vector3 newPosition = transform.position;
            newPosition.x += movementSpeed;
            gameObject.transform.position = newPosition;
            movement = 0;

            Vector3 spin = transform.localScale;
            spin.x = Mathf.Abs(spin.x);
            transform.localScale = spin;
        }

        if (movement < 0) {
            transform.Translate(Vector3.left * movementSpeed);
            movement = 0;

            Vector3 spin = transform.localScale;
            spin.x = -Mathf.Abs(spin.x);
            transform.localScale = spin;
        }
    }

    void Jump() {
        Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        GetComponent<Animator>().SetBool("jump", true);
    }

    public void ResetJumpCount() {
        jumpCount = 0;
    }
}
