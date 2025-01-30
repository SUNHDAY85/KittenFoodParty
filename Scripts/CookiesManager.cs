using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CookiesManager : MonoBehaviour
{
    public TextMeshPro totalCookiesText;
    public TextMeshPro cookiesCollectedText;
    private int totalCookiesinScene;

    public GameObject goldenCookie;
    public float goldenCookieplayTime = 3.0f; // Tiempo antes de desaparecer la galleta dorada
    private int totalFishCookies = 9; // Número total de galletas en la escena
    private int collectedFishCookies = 0; // Número de galletas recolectadas

    private bool goldenCookieShown = false; // Para evitar mostrar la galleta dorada más de una vez

    private void Start()
    {
        totalCookiesinScene = transform.childCount; // Asigna la cantidad total de galletas en la escena
        totalFishCookies = totalCookiesinScene - 1; // Calcula las FishCookies excluyendo la galleta dorada
        collectedFishCookies = 0; // Inicializamos el contador de galletas recolectadas a 0

        goldenCookie.SetActive(false); // Asegúrate de que la galleta dorada esté desactivada al inicio
        UpdateCookiesTextMeshPro(); // Actualiza los textos al inicio
    }

    public void UpdateCookiesTextMeshPro()
    {
        // Actualiza el texto en la UI con el total de galletas y las recolectadas
        totalCookiesText.text = "Total Cookies: " + totalCookiesinScene;
        cookiesCollectedText.text = "Collected: " + collectedFishCookies;
    }

    public void CollectCookie()
    {
        if (!goldenCookieShown) // Si la galleta dorada ya fue mostrada, no hace nada
        {
            collectedFishCookies++; // Incrementa el contador de galletas recolectadas
            Debug.Log("Cookies collected: " + collectedFishCookies);

            // Actualiza el contador de texto después de recolectar una galleta
            UpdateCookiesTextMeshPro();

            // Si ya se recolectaron todas las galletas, mostramos la galleta dorada
            if (collectedFishCookies == totalFishCookies)
            {
                Debug.Log("You found the Golden Cookie!!!");
                goldenCookie.SetActive(true); // Mostrar la Golden Cookie
                goldenCookieShown = true; // Asegura que solo se muestre una vez

                // Destruir la Golden Cookie después de un tiempo
                StartCoroutine(DestroyGoldenCookieAfterTime());
            }
        }
    }

    private IEnumerator DestroyGoldenCookieAfterTime()
    {
        // Espera el tiempo especificado antes de desactivar la galleta dorada
        yield return new WaitForSeconds(goldenCookieplayTime);
        goldenCookie.SetActive(false); // Desactiva la galleta dorada después de un tiempo
    }
}

