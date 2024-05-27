using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCustomMaterial", menuName = "Custom Material")]
public class CustomMaterial : ScriptableObject
{
    public Color color;
    public float shininess;
    public Texture texture;
}
