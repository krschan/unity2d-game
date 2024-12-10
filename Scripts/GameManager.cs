using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateCoins());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int numberCoinDestroyed = 0;
    bool createCoins = true;
    [SerializeField] GameObject coinPrefab;

    IEnumerator CreateCoins() {
        while (createCoins) 
        {
            float posX = UnityEngine.Random.Range(-5f, 5f);
            Vector2 positionCoin = new Vector2(posX, 5f);
            Instantiate(coinPrefab, positionCoin, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
}
