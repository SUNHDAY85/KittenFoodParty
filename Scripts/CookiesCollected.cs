using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookiesCollected : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            // If the cookie is a child of another object, you can use
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            FindObjectOfType<CookiesManager>().AllCookiesCollected();
            
            Destroy(gameObject, 0.5f);
        }
    }


}
