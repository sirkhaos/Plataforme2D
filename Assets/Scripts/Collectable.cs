using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    private static int collectableQuantity = 0;
    private Text textCollectable;
    private ParticleSystem collectableParticle;
    private AudioSource FXS;
    // Start is called before the first frame update
    void Start()
    {
        collectableParticle = GameObject.Find("CollectableParticle").GetComponent<ParticleSystem>();
        FXS = GetComponentInParent<AudioSource>();
        textCollectable = GameObject.Find("CollectableQuantityText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            collectableParticle.transform.position = transform.position;
            collectableParticle.Play();
            FXS.Play();
            gameObject.SetActive(false);
            collectableQuantity++;
            textCollectable.text = collectableQuantity.ToString("000");
        }
    }
}
