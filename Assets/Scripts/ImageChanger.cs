using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Image[] images; 
    public Sprite[] newSprites; 

    public void ChangeImages()
    {
        if (images.Length != newSprites.Length)
        {
            Debug.LogError("The number of images and sprites must match!");
            return;
        }

        for (int i = 0; i < images.Length; i++)
        {
            images[i].sprite = newSprites[i];
        }
    }
}
