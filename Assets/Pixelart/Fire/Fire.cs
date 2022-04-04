using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sprite))]
public class Fire : MonoBehaviour
{
    private Sprite Sprite;
    void Start()
    {
        Sprite = GetComponent<Sprite>();
        Sprite.GenerateAnimation("fire", 0, 11, 0.1f, true);
        Sprite.Play("fire");
    }

    void Update()
    {

    }
}