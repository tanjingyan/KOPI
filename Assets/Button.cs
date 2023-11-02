using UnityEngine;
using UnityEngine.UI;

public class ImageButtonHandler : MonoBehaviour
{
    public Image imageDisplay; // Reference to an Image component to display the selected image.
    public Sprite[] images; // List of images to choose from.

    private int currentImageIndex = 0;

    private void Start()
    {
        // Initialize the image display with the first image.
        ShowImage(currentImageIndex);
    }

    public void ShowNextImage()
    {
        // Display the next image when the button is clicked.
        currentImageIndex = (currentImageIndex + 1) % images.Length;
        ShowImage(currentImageIndex);
    }

    public void ShowPreviousImage()
    {
        // Display the previous image when the button is clicked.
        currentImageIndex = (currentImageIndex - 1 + images.Length) % images.Length;
        ShowImage(currentImageIndex);
    }

    private void ShowImage(int index)
    {
        // Display the image at the specified index.
        if (index >= 0 && index < images.Length)
        {
            imageDisplay.sprite = images[index];
        }
    }
}