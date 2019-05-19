using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int hp = 3;
    public Image[] hearts;
    private bool hasCooldown = false;
    private const string SceneLose = "SampleScene";
    private SceneChanger changerScene;

    private void Start()
    {
        changerScene = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (GetComponent<PlayerController>().isGrounded)
            {
                SubstractHearth();
            }
        }
        if (collision.gameObject.CompareTag("Out"))
        {
            changerScene.ChangeSceneTo(SceneLose);
        }
    }

    public void SubstractHearth()
    {
        if (!hasCooldown)
        {
            if (hp > 0)
            {
                hp--;
                hasCooldown = true;
                StartCoroutine(Cooldown());
            }
            if (hp <= 0)
            {
                //changerScene.ChangeSceneTo("LoseScene");
                changerScene.ChangeSceneTo(SceneLose);
            }
            EmptyHearts();
        }
    }

    private void EmptyHearts()
    {
        for(int i=0; i < hearts.Length; i++)
        {
            if (hp - 1 < i)
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.5f);
        hasCooldown = false;
        StopCoroutine(Cooldown());
    }
}
