using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    void Start() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Ground") {
            GameObject.Find("Player").GetComponent<PlayerAnimation>().ResetJumpCount();
            GameObject.Find("Player").GetComponent<Animator>().SetBool("jump", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Ground") {
            GameObject.Find("Player").GetComponent<Animator>().SetBool("jump", true);
        }
    }
}
