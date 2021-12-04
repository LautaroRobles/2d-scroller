using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public ComputeShader ComputeShader;
    private RenderTexture OutputTexture;
    private Texture2D InputTexture;
    private MeshRenderer MeshRenderer;
    public int Resolution;

    // Water spring config
    public float TargetHeight = 0.5f;
    public float K = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        InitializeTextures();

        MeshRenderer = GetComponent<MeshRenderer>();
    }

    private void InitializeTextures()
    {
        // Compute shader's input
        InputTexture = new Texture2D(Resolution, Resolution);
        InputTexture.SetPixels(new Color[Resolution * Resolution]);
        InputTexture.Apply();

        // Compute shader's output
        OutputTexture = new RenderTexture(Resolution, Resolution, 24);
        OutputTexture.enableRandomWrite = true;
        OutputTexture.Create();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int size = 2;
            int x = Random.Range(0, Resolution);
            int y = Random.Range(0, Resolution);

            x = 128;
            y = 128;

            Color[] colors = new Color[size * size];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = new Color(0.5f, 0f, 0f, 1);
            }

            InputTexture.SetPixels(x, y, size, size, colors, 0);
            InputTexture.Apply();
        }

        Debug.Log(InputTexture.GetPixel(128, 128));

        MeshRenderer.material.SetTexture("_MainTex", OutputTexture);

        DispatchComputeShader();
        SetOutputAsInput();
    }
    private void DispatchComputeShader()
    {
        int kernelIndex = 0;
        int threads = 8;

        ComputeShader.SetFloat("TargetHeight", TargetHeight);
        ComputeShader.SetFloat("K", K);

        ComputeShader.SetTexture(kernelIndex, "Input", InputTexture);
        ComputeShader.SetTexture(kernelIndex, "Output", OutputTexture);

        ComputeShader.Dispatch(kernelIndex, OutputTexture.width / threads, OutputTexture.height / threads, 1);
    }

    private void SetOutputAsInput()
    {
        RenderTexture.active = OutputTexture;
        InputTexture.ReadPixels(new Rect(0, 0, Resolution, Resolution), 0, 0);
        InputTexture.Apply();
    }
}
