using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sprite))]
public class CharacterRender : MonoBehaviour
{
    private Sprite Sprite;
    void Start()
    {
        Sprite = GetComponent<Sprite>();
        Sprite.GenerateAnimation("idle", 0, 0, 0.1f, false);
        Sprite.Play("idle");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
