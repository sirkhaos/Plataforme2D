using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    private static int collectableQuantity = 0;
    [SerializeField]
    private Text textCollectable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            gameObject.SetActive(false);
            collectableQuantity++;
            textCollectable.text = collectableQuantity.ToString("000");
        }
    }
}
