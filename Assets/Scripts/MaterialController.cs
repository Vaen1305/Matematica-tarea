using UnityEngine;

public class MaterialController : MonoBehaviour
{
    public CustomMaterial customMaterial;
    private Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        material.color = customMaterial.color;
        material.mainTexture = customMaterial.texture;
        material.SetFloat("_Shininess", customMaterial.shininess);
    }
}
