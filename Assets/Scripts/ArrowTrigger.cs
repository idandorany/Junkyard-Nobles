using UnityEngine;

public class ArrowTrigger : MonoBehaviour
{
    [SerializeField] private ArrowKey arrowKey;

    public ArrowKey GetArrowKey()
    {
        return arrowKey;
    }
}
