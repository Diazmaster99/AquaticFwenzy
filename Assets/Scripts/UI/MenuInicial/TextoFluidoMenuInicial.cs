using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextoFluidoMenuInicial : MonoBehaviour
{
    public TMP_Text textoMenuInicial;
    private Color startColor = new Color(0, 1, 0.816f); // #00FFD0
    private Color endColor = new Color(0.851f, 0.745f, 0.18f, 1.0f); // #D9BE2E
    public float speed = 5f; // Speed of color change
    public float timer;
    private Coroutine timerCoroutine;
    void Start()
    {
        
        timerCoroutine = StartCoroutine(InitializeScript());
    }

    IEnumerator InitializeScript()
    {
        float segundos = 0f;
        while (segundos < timer)
        {
            MoveText();

            yield return null;

            segundos += Time.deltaTime;
        }
        timerCoroutine = null;
    }

    void MoveText()
    {
        textoMenuInicial.ForceMeshUpdate();
        var textInfo = textoMenuInicial.textInfo;

        // Para que el texto se vaya moviendo de arriba abajo de una manera curiosa
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            var charInfo = textInfo.characterInfo[i];

            if (!charInfo.isVisible)
            {
                continue;
            }

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            // Ensure the vertex index is within bounds
            if (charInfo.vertexIndex >= verts.Length)
            {
                continue;
            }

            // Calculate the number of vertices for this character
            int numVertices = textInfo.meshInfo[charInfo.materialReferenceIndex].vertexCount / 4;

            for (int j = 0; j < numVertices; j++)
            {
                var origIndex = charInfo.vertexIndex + j;

                // Ensure the vertex index is within bounds
                if (origIndex >= verts.Length)
                {
                    continue;
                }

                // Update the vertex position
                var orig = verts[origIndex];
                verts[origIndex] = orig + new Vector3(0, Mathf.Sin(Time.time * 0.5f + orig.x * 0.01f) * 10f, 0);
            }
        }

        // Update geometry for each material
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            textoMenuInicial.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
