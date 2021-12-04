using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeShaderTest : MonoBehaviour
{
    public ComputeShader computeShader;
    private RenderTexture outputTexture;
    private Texture2D inputTexture;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        inputTexture = new Texture2D(256, 256);
        inputTexture.SetPixels(new Color[256 * 256]);
        inputTexture.Apply();

        // Create texture to write
        outputTexture = new RenderTexture(256, 256, 24);
        outputTexture.enableRandomWrite = true;
        outputTexture.Create();


        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Color[] colors = new Color[16 * 16];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = Color.white;
            }

            inputTexture.SetPixels(120, 120, 16, 16, colors, 0);
            inputTexture.Apply();
        }

        computeShader.SetTexture(0, "Input", inputTexture);
        computeShader.SetTexture(0, "Output", outputTexture);
        computeShader.Dispatch(0, outputTexture.width / 8, outputTexture.height / 8, 1);

        meshRenderer.material.SetTexture("_MainTex", outputTexture);
        inputTexture = toTexture2D(outputTexture);
    }

    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(256, 256);
        // ReadPixels looks at the active RenderTexture.
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
}
