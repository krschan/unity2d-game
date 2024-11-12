using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    int jumpCount = 0; // Contador de saltos
    float movement = 0;
    [SerializeField] float jumpSpeed = 5f; // Ajusta la velocidad de salto
    [SerializeField] float movementSpeed = 0.1f;
    [SerializeField] LayerMask groundLayer; // Capa para detectar el suelo
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        movement = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }

    void FixedUpdate() {
        HandleMovement();
    }

    private void HandleMovement() {
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

            // Rotar donde mira el jugador
            Vector3 spin = transform.localScale;
            spin.x = Mathf.Abs(spin.x);
            transform.localScale = spin;
        }

        if (movement < 0) {
            transform.Translate(Vector3.left * movementSpeed);
            movement = 0;

            // Rotar donde mira el jugador
            Vector3 spin = transform.localScale;
            spin.x = -Mathf.Abs(spin.x);
            transform.localScale = spin;
        }
    }

    private void Jump() {
        // Verifica si el jugador está en el suelo
        if (IsGrounded()) {
            jumpCount = 0; // Reinicia el contador de saltos al tocar el suelo
        }

        if (jumpCount < 2) { // Permitir hasta 2 saltos
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    private bool IsGrounded() {
        // Verifica si el jugador está tocando el suelo
        return Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);
    }

    public bool IsJumping() {
        return jumpCount > 0; // Devuelve verdadero si ha saltado al menos una vez
    }

}
