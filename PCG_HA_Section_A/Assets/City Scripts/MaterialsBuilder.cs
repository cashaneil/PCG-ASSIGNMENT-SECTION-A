using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsBuilder : MonoBehaviour
{
    private List<Material> materialsList = new List<Material>();

    public MaterialsBuilder()
    {
        Material greyMaterial = new Material(Shader.Find("Specular"));
        greyMaterial.color = Color.grey;

        Material redMaterial = new Material(Shader.Find("Specular"));
        redMaterial.color = Color.red;

        Material greenMaterial = new Material(Shader.Find("Specular"));
        greenMaterial.color = Color.green;

        Material blueMaterial = new Material(Shader.Find("Specular"));
        blueMaterial.color = Color.blue;

        Material yellowMaterial = new Material(Shader.Find("Specular"));
        yellowMaterial.color = Color.yellow;

        Material magentaMaterial = new Material(Shader.Find("Specular"));
        magentaMaterial.color = Color.magenta;

        Material whiteMaterial = new Material(Shader.Find("Specular"));
        whiteMaterial.color = Color.white;

        Material blackMaterial = new Material(Shader.Find("Specular"));
        blackMaterial.color = Color.black;

        materialsList.Add(greyMaterial);
        materialsList.Add(redMaterial);
        materialsList.Add(greenMaterial);
        materialsList.Add(blueMaterial);
        materialsList.Add(yellowMaterial);
        materialsList.Add(magentaMaterial);
        materialsList.Add(whiteMaterial);
        materialsList.Add(blackMaterial);
    }

    public List<Material> MaterialsList()
    {
        return materialsList;
    }
}
