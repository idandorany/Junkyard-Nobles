using UnityEngine;

public class ArrowTrigger : MonoBehaviour
{
    [SerializeField] private ArrowKey arrowKey;
    [SerializeField] private ParticleSystem _particleSystemPrefab;

    public ArrowKey GetArrowKey()
    {
        return arrowKey;
    }
    public void PlayParticleEffect()
    {
        ParticleSystem particleSys = Instantiate(_particleSystemPrefab);

        // Convert the UI element's screen position to world space.
        RectTransform uiTransform = GetComponent<RectTransform>();
        Vector3 screenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, uiTransform.position);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, Camera.main.nearClipPlane + 1.0f)); // Adjust z for depth.

        // Set the particle system's position.
        particleSys.transform.position = worldPosition;

        // Play the particle system.
        particleSys.Play();

        // Destroy the particle system after its duration.
        Destroy(particleSys.gameObject, particleSys.main.duration);
    }

}
