using UnityEngine;

public class AudioManger : MonoBehaviour
{
  public static AudioManger Instance;

    
    [SerializeField] AudioSource Nots;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
