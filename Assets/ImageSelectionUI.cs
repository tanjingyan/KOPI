using UnityEngine;
using UnityEngine.UI;

public class ImageSelectionUI : MonoBehaviour
{
    public Image displayImage;
    public GameObject imageSelectionUI;

    private Sprite selectedImage;

    public void OpenImageSelectionUI()
    {
        imageSelectionUI.SetActive(true);
    }

    public void ChooseImage(Sprite image)
    {
        selectedImage = image;
        displayImage.sprite = selectedImage;
        imageSelectionUI.SetActive(false);
    }
}


