using UnityEngine;
using Normal.Realtime;

public class ColorSync : RealtimeComponent<ColorSyncModel>
{
    [SerializeField] private MeshRenderer[] meshRenderers;
    [SerializeField] private Color color;
    private Color lastColor;

    private void Update()
    {
        if (color != lastColor)
        {
            model.color = color;
            lastColor = color;
        }
    }

    private void Start()
    {
        var randomColor = new Color(Random.value, Random.value, Random.value);
        model.color = randomColor;
    }

    private void UpdateMeshRendererColor()
    {
        foreach (var renderer in meshRenderers)
        {
            foreach (var mat in renderer.materials)
                mat.color = model.color;
        }
    }

    protected override void OnRealtimeModelReplaced(ColorSyncModel previousModel, ColorSyncModel currentModel)
    {
        if (previousModel != null)
            previousModel.colorDidChange -= DidColorChange;

        if (currentModel.isFreshModel)
            currentModel.color = meshRenderers[0].material.color;

        UpdateMeshRendererColor();

        currentModel.colorDidChange += DidColorChange;
    }

    private void DidColorChange(ColorSyncModel model, Color value) => UpdateMeshRendererColor();
}
