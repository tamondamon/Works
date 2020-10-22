using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton : MonoBehaviour
{
    public Material material;
    public SetColor setcolor;

    // Update is called once per frame
    public void OnClick()
    {
         setcolor.SetMaterial(material);
    }
}
