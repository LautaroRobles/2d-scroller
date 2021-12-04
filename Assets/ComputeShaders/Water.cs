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
    public float K = 0.01f;
    public float D = 0.01f;
    public float Spread = 0.25f;
    public float MaxHeight = 1f;

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
        var defaultValues = new Color[Resolution * Resolution];
        for (var i = 0; i < Resolution * Resolution; i++)
        {
            defaultValues[i] = new Color(0.5f, 0.5f, 0, 1);
        }
        InputTexture.SetPixels(0, 0, Resolution, Resolution, defaultValues);
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
            int size = 16;
            int x = Random.Range(0, Resolution);
            int y = Random.Range(0, Resolution);

            Color[] colors = new Color[size * size];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = new Color(1f, 0f, 0f, 1);
            }

            InputTexture.SetPixels(x, y, size, size, colors, 0);
            InputTexture.Apply();
        }

        MeshRenderer.material.SetTexture("_MainTex", OutputTexture);
        MeshRenderer.material.SetTexture("_HeightMap", OutputTexture);

        DispatchComputeShader();
        SetOutputAsInput();
    }
    private void DispatchComputeShader()
    {
        int kernelIndex = 0;
        int threads = 8;

        ComputeShader.SetFloat("TargetHeight", TargetHeight);
        ComputeShader.SetFloat("K", K);
        ComputeShader.SetFloat("D", D);
        ComputeShader.SetFloat("Spread", Spread);
        ComputeShader.SetFloat("MaxHeight", MaxHeight);

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
