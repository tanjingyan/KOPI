using UnityEngine;

public class ImageDisplay : MonoBehaviour
{
    public Material imageMaterial;
    public Texture2D[] images; // Array of image textures to display.

    private int currentImageIndex = 0;

    void Start()
    {
        // Initialize the material with the first image.
        UpdateMaterial();
    }

    public void NextImage()
    {
        currentImageIndex = (currentImageIndex + 1) % images.Length;
        UpdateMaterial();
    }

    public void PreviousImage()
    {
        currentImageIndex = (currentImageIndex - 1 + images.Length) % images.Length;
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        if (imageMaterial != null && images.Length > 0)
        {
            imageMaterial.mainTexture = images[currentImageIndex];
        }
    }
}
