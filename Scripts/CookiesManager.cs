using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookiesManager : MonoBehaviour
{
    public GameObject goldenCookie;
    public float goldenCookieplayTime = 3.0f; // Tiempo antes de desaparecer la galleta dorada 
    private int totalFishCookies = 9; // Número total de galletas en la escena
    private int collectedFishCookies = 0; // Número de galletas recolectadas

    private bool goldenCookieShown = false; // Para evitar mostrar la galleta dorada más de una vez

    private void Start()
    {
        // Contar todas las FishCookies en la escena
        totalFishCookies = transform.childCount - 1; // Calculamos las FishCookies que hay en la escena (asumiendo que el objeto de galletas doradas no es hijo de CookiesManager)
        collectedFishCookies = 0;  // Inicializamos en 0 la cantidad de galletas recolectadas 
    }
    
    public void CollectCookie()
    {
        if (!goldenCookieShown) // Si la galleta dorada ya fue mostrada, no hace nada
        {
            collectedFishCookies++; // Incrementa el contador de galletas recolectadas
            Debug.Log("Cookies collected: " + collectedFishCookies);

          if (collectedFishCookies == totalFishCookies)
          {
             Debug.Log("You found the Golden Cookie!!!");
             goldenCookie.SetActive(true); // Mostrar la Golden Cookie
             goldenCookieShown = true;  // Asegura que solo se muestre una vez

              // Destruir la Golden Cookie después de un tiempo
             StartCoroutine(DestroyGoldenCookieAfterTime());
          }
        
        }
    }

    private IEnumerator DestroyGoldenCookieAfterTime()
    {
        yield return new WaitForSeconds(goldenCookieplayTime);
        goldenCookie.SetActive(false);
    }
}
