using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStompMonster : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Weakpoint") {
            Destroy(collision.gameObject);
        }
    }
}
