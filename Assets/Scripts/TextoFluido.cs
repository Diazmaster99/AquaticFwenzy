using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextoFluido : MonoBehaviour
{

    private TMP_Text textoInicio;
    private Color startColor = new Color(0, 1, 0.816f); // #00FFD0
    private Color endColor = new Color(0.851f, 0.745f, 0.18f, 1.0f); // #D9BE2E
    public float speed = 5f; // Speed of color change
    void Start()
    {
        textoInicio = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        changeColor();

        textoInicio.ForceMeshUpdate();
        var textInfo = textoInicio.textInfo;

        //Para que el texto se vaya moviendo de arriba abajo de una manera curiosa
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            var charInfo = textInfo.characterInfo[i];

            if (!charInfo.isVisible)
            {
                continue;
            }

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 8; j++)
            {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * 2f + orig.x * 0.01f) * 10f, 0);
            }

        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            textoInicio.UpdateGeometry(meshInfo.mesh, i);
        }

        

    }

    void changeColor()
    {
        // Calculate the interpolation factor based on time and speed
        float t = Mathf.PingPong(Time.time * speed, 1f);

        // Interpolate between startColor and endColor using the factor t
        Color lerpedColor = Color.Lerp(startColor, endColor, t);

        // Apply the lerped color to the text
        textoInicio.color = lerpedColor;
    }

}
