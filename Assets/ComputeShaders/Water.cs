using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public ComputeShader ComputeShader;
    private RenderTexture OutputTexture;
    private MeshRenderer MeshRenderer;
    public int Resolution;

    // Water spring config
    public float TargetHeight = 0f;
    public float K = 0.01f;
    public float D = 0.01f;
    public float Spread = 0.25f;
    public float MaxHeight = 1f;
    private struct WaterPoint
    {
        float height;
        float velocity;
        public WaterPoint(float _height, float _velocity)
        {
            height = _height;
            velocity = _velocity;
        }
    }
    private WaterPoint[] PointsInput;
    private WaterPoint[] PointsOutput;
    private ComputeBuffer InputBuffer;
    private ComputeBuffer OutputBuffer;

    // Start is called before the first frame update
    void Start()
    {
        InitializeTextures();
        InitializePoints();
        InitializeBuffers();

        MeshRenderer = GetComponent<MeshRenderer>();
    }
    private void InitializeTextures()
    {
        // Compute shader's output
        OutputTexture = new RenderTexture(Resolution, Resolution, 24);
        OutputTexture.enableRandomWrite = true;
        OutputTexture.Create();
    }
    private void InitializePoints()
    {
        PointsInput = new WaterPoint[Resolution * Resolution];
        PointsOutput = new WaterPoint[Resolution * Resolution];
    }
    private void InitializeBuffers()
    {
        int waterPointStride = sizeof(float) + sizeof(float);

        InputBuffer = new ComputeBuffer(PointsInput.Length, waterPointStride);
        OutputBuffer = new ComputeBuffer(PointsOutput.Length, waterPointStride);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PointsInput[Random.Range(0, Resolution * Resolution)] = new WaterPoint(2, 2);
        }

        MeshRenderer.material.SetTexture("_MainTex", OutputTexture);
        MeshRenderer.material.SetTexture("_HeightMap", OutputTexture);

        DispatchComputeShader();
        //SetOutputAsInput();
    }
    private void DispatchComputeShader()
    {
        int kernelIndex = 0;
        int threads = 1;

        InputBuffer.SetData(PointsInput);
        OutputBuffer.SetData(PointsOutput);

        ComputeShader.SetInt("Resolution", Resolution);
        ComputeShader.SetFloat("TargetHeight", TargetHeight);
        ComputeShader.SetFloat("K", K);
        ComputeShader.SetFloat("D", D);
        ComputeShader.SetFloat("Spread", Spread);

        ComputeShader.SetTexture(kernelIndex, "Output", OutputTexture);

        ComputeShader.SetBuffer(kernelIndex, "PointsInput", InputBuffer);
        ComputeShader.SetBuffer(kernelIndex, "PointsOutput", OutputBuffer);

        ComputeShader.Dispatch(kernelIndex, OutputTexture.width / threads, OutputTexture.height / threads, 1);

        OutputBuffer.GetData(PointsInput);
    }

    /*
    private void SetOutputAsInput()
    {
        RenderTexture.active = OutputTexture;
        InputTexture.ReadPixels(new Rect(0, 0, Resolution, Resolution), 0, 0);
        InputTexture.Apply();
    }
    */

    void OnDisable()
    {
        InputBuffer.Dispose();
        OutputBuffer.Dispose();
    }
}
