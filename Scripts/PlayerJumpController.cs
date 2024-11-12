using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    private Animator animator;
    private PlayerAnimation playerAnimation;

    void Start()
    {
        animator = GameObject.Find("Player").GetComponent<Animator>();
        playerAnimation = GameObject.Find("Player").GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        // Actualiza la animación de salto basado en el estado del salto
        if (playerAnimation.IsJumping())
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            animator.SetBool("jump", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            animator.SetBool("jump", true);
        }
    }
}
