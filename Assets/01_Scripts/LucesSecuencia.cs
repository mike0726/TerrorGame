using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LucesSecuencia : MonoBehaviour
{
    [Header("2D Lights")]
    public Light2D[] lights; // Array para las luces 2D (asignadas desde el editor)

    [Header("Settings")]
    public float lightDuration = 2f; // Tiempo que dura cada luz encendida (en segundos)

    private int currentActiveLight = 0; // Índice de la luz actualmente encendida
    private int previousActiveLight = -1; // Para evitar que se repita inmediatamente la misma luz

    private void Start()
    {
       

        // Inicia la secuencia con la primera luz encendida
        InitializeLights();
        StartCoroutine(LightSequence());
    }

    private void InitializeLights()
    {
        // Apaga todas las luces inicialmente
        foreach (Light2D light in lights)
        {
            light.enabled = false;
        }

        // Enciende la primera luz (la que está encima del jugador)
        lights[0].enabled = true;
        currentActiveLight = 0;
    }

    private IEnumerator LightSequence()
    {
        while (true)
        {
            yield return new WaitForSeconds(lightDuration);

            // Elige la siguiente luz aleatoria (excepto la primera y sin repetir inmediatamente)
            int nextLight = GetRandomLightIndex();

            // Apaga la luz actual (excepto la primera)
            if (currentActiveLight != 0)
            {
                lights[currentActiveLight].enabled = false;
            }

            // Enciende la siguiente luz
            lights[nextLight].enabled = true;

            // Actualiza los índices
            previousActiveLight = currentActiveLight;
            currentActiveLight = nextLight;
        }
    }

    private int GetRandomLightIndex()
    {
        int randomIndex;

        do
        {
            randomIndex = Random.Range(1, lights.Length); // Excluye la primera luz
        } while (randomIndex == previousActiveLight); // Evita repetir inmediatamente

        return randomIndex;
    }
}
