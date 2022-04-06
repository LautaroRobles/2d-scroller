using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sprite))]
public class PlayerRender : MonoBehaviour
{
    private Sprite Sprite;
    void Start()
    {
        Sprite = GetComponent<Sprite>();
        Sprite.GenerateAnimation("idle", 2, 2, 0.1f, false);
        Sprite.GenerateAnimation("run", 13, 16, 0.1f, true);
        Sprite.Play("idle");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
