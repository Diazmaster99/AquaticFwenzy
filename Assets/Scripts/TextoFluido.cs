using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextoFluido : MonoBehaviour
{

    public TMP_Text textoInicio;
    public float speed = 3f; // Speed of color change
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //textoInicio.ForceMeshUpdate();
        //var textInfo = textoInicio.textInfo;

        ////Para que el texto se vaya moviendo de arriba abajo de una manera curiosa
        //for (int i = 0; i < textInfo.characterCount; i++)
        //{
        //    var charInfo = textInfo.characterInfo[i];

        //    if (!charInfo.isVisible)
        //    {
        //        continue;
        //    }

        //    var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

        //    for (int j = 0; j < 8; j++)
        //    {
        //        var orig = verts[charInfo.vertexIndex + j];
        //        verts[charInfo.vertexIndex + j] = orig + new Vector3(0,Mathf.Sin(Time.time*2f + orig.x*0.01f)*10f,0);
        //    }

        //}

        //for (int i = 0; i < textInfo.meshInfo.Length; i++)
        //{
        //    var meshInfo = textInfo.meshInfo[i];
        //    meshInfo.mesh.vertices = meshInfo.vertices;
        //    textoInicio.UpdateGeometry(meshInfo.mesh, i);
        //}

        //Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        //textoInicio.colorGradientPreset.topRight = color;

        // color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        //textoInicio.colorGradientPreset.topLeft = color;

        //color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        //textoInicio.colorGradientPreset.bottomRight = color;

        //color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        //textoInicio.colorGradientPreset.bottomLeft = color;

        // Calculate the hue based on time and speed
        float hue = Time.time * speed % 1;

        // Convert HSV color to RGB color
        Color color = Color.HSVToRGB(hue, 1, 1);

        // Apply the color to the text
        textoInicio.color = color;

    }

    void ChangeColors()
    {

    }

}
