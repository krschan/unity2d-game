using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAttackPrefabManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelfDestroy()
    {
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Coin")
        {
            Destroy(collision.gameObject);
            GameObject textCoin=GameObject.Find("TextCoinUI");
            int totalCoinDestroyed = ++GameObject.Find("GameManager").GetComponent<GameManager>().numberCoinDestroyed;
            textCoin.GetComponent<TextMeshProUGUI>().SetText(totalCoinDestroyed + "");
        }
    }
}
