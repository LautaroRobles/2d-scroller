using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixelart : MonoBehaviour
{
    private const float PixelScale = 16;
    public GameObject PixelPrefab;
    private GameObject[] Pixels;
    private Texture2D Spritesheet;
    private int SpriteWidth;
    private int SpriteHeight;
    private Dictionary<string, Animation> Animations;
    private struct Animation
    {
        public int Start;
        public int End;
        public float FrameRate;
        public bool Loop;
        public Animation(int start, int end, float frameRate, bool loop)
        {
            Start = start;
            End = end;
            FrameRate = frameRate;
            Loop = loop;
        }
    }
    private string AnimationToPlay;
    private int AnimationPlayCount;
    private int PreviousFrame = -1;
    private float FrameTimeStart;


    public void InstantiateSprite(Texture2D spritesheet, int spriteWidth, int spriteHeight, Vector2 center)
    {
        if (PixelPrefab == null)
            return;

        Spritesheet = spritesheet;
        SpriteWidth = spriteWidth;
        SpriteHeight = spriteHeight;

        Pixels = new GameObject[spriteWidth * spriteHeight];

        var i = 0;
        for (var x = 0; x < spriteWidth; x++)
        {
            for (var y = 0; y < spriteHeight; y++)
            {
                Pixels[i] = Instantiate(PixelPrefab);
                Pixels[i].transform.parent = transform;
                Pixels[i].transform.localPosition = new Vector3((x - center.x * spriteWidth + 0.5f) / PixelScale, (y - center.y * spriteHeight + 0.5f) / PixelScale, 0);
                Pixels[i].transform.localScale = new Vector3(1 / PixelScale, 1 / PixelScale, 1 / PixelScale);
                Pixels[i].SetActive(false);
                i++;
            }
        }
    }

    /// <summary>
    /// Generates animation data, then to play an animation use Play(name)
    /// </summary>
    /// <param name="name">Name of animation</param>
    /// <param name="start">Start frame</param>
    /// <param name="end">End frame</param>
    /// <param name="frameRate">Frame rate in fps (1 = 1 second each frame)</param>
    /// <param name="loop">Should loop</param>
    public void GenerateAnimation(string name, int start, int end, float frameRate, bool loop)
    {
        if (Animations == null)
            Animations = new Dictionary<string, Animation>();

        Animation animation = new Animation(start, end, frameRate, loop);

        Animations.Add(name, animation);
    }
    /// <summary>
    /// Plays animation by given name, should be called after GenerateAnimation()
    /// </summary>
    /// <param name="name">Name of animation to play</param>
    public void Play(string name)
    {
        AnimationToPlay = name;
        AnimationPlayCount = 0;
        FrameTimeStart = Time.time;
    }
    public void Stop()
    {
        AnimationToPlay = "";
    }

    private void RenderFrame(int frame)
    {
        var i = 0;
        for (var x = 0; x < SpriteWidth; x++)
        {
            for (var y = 0; y < SpriteHeight; y++)
            {
                if (i >= Pixels.Length)
                    return;

                Color color = Spritesheet.GetPixel(
                    x + (frame * SpriteWidth) % Spritesheet.width,
                    y + Mathf.FloorToInt(frame * SpriteWidth / Spritesheet.width) * SpriteHeight
                );

                if (color.a == 0)
                    Pixels[i].SetActive(false);
                else
                    Pixels[i].SetActive(true);

                Material material = Pixels[i].GetComponent<MeshRenderer>().material;
                material.SetColor("_Color", color);

                i++;
            }
        }
    }

    void Update()
    {
        if (Animations == null)
            return;

        if (AnimationToPlay == "" || AnimationToPlay == null)
            return;

        if (!Animations.ContainsKey(AnimationToPlay))
            return;

        if (!Animations[AnimationToPlay].Loop && AnimationPlayCount > 0)
            return;

        Animation animationToPlay = Animations[AnimationToPlay];

        int frameToPlay = Mathf.FloorToInt((Time.time - FrameTimeStart) / animationToPlay.FrameRate + animationToPlay.Start) % (animationToPlay.End + 1);

        if (PreviousFrame != frameToPlay)
        {
            if (PreviousFrame == (animationToPlay.End) && frameToPlay == animationToPlay.Start)
                AnimationPlayCount++;

            RenderFrame(frameToPlay);
            PreviousFrame = frameToPlay;
        }
    }
}
