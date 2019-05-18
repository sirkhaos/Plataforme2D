using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private SceneChanger changerScene;

    private void Start()
    {
        changerScene = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            changerScene.NextScene();
        }
    }
}
