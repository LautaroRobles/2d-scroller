using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour, IPooledObject
{
    private Sprite Sprite;
    public int Frames;
    public float FrameRate = 0.1f;
    void Awake()
    {
        Sprite = GetComponentInChildren<Sprite>();
        Sprite.GenerateAnimation("explode", 0, Frames, FrameRate, false);
    }
    void OnEnable()
    {
        Sprite.OnLoop += Disable;
    }
    void OnDisable()
    {
        Sprite.OnLoop -= Disable;
    }
    public void OnObjectSpawn()
    {
        Sprite.Play("explode");
    }
    void Disable(string animation)
    {
        gameObject.SetActive(false);
    }
}
