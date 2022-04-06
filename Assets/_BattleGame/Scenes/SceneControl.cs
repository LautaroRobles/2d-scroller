using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1)
            SceneManager.LoadScene(1);
    }
}
