using UnityEngine;
using System.Collections;

public class ButtonAnimation : MonoBehaviour 
{
    [Header("Animation Settings")]
    [SerializeField] private float pulseScale = 1.1f;
    [SerializeField] private float pulseDuration = 1f;
    
    private Vector3 originalScale;
    
    void Start()
    {
        originalScale = transform.localScale;
        // Iniciar la animación al comenzar
        StartCoroutine(PulseAnimation());
    }
    
    private IEnumerator PulseAnimation()
    {
        while (true)
        {
            // Aumentar escala
            float elapsedTime = 0f;
            while (elapsedTime < pulseDuration / 2)
            {
                elapsedTime += Time.deltaTime;
                float progress = elapsedTime / (pulseDuration / 2);
                transform.localScale = Vector3.Lerp(originalScale, originalScale * pulseScale, progress);
                yield return null;
            }
            
            // Disminuir escala
            elapsedTime = 0f;
            while (elapsedTime < pulseDuration / 2)
            {
                elapsedTime += Time.deltaTime;
                float progress = elapsedTime / (pulseDuration / 2);
                transform.localScale = Vector3.Lerp(originalScale * pulseScale, originalScale, progress);
                yield return null;
            }
            
            yield return null;
        }
    }
}