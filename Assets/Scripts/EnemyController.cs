using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private float timeBeforeChange;
    private Rigidbody2D enemyRb;
    private SpriteRenderer enemySR;
    private Animator enemyAnim;
    private ParticleSystem enemyParticle;
    private AudioSource deadFXS;

    [SerializeField]
    private float delay = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemySR = GetComponent<SpriteRenderer>();
        enemyAnim = GetComponent<Animator>();
        enemyParticle = GameObject.Find("EnemyParticle").GetComponent<ParticleSystem>();
        deadFXS = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.velocity = Vector2.right * speed;
        if (speed < 0)
        {
            enemySR.flipX = true;
        }
        else
        {
            enemySR.flipX = false;
        }


        if (timeBeforeChange < Time.time)
        {
            speed *= -1;
            timeBeforeChange = Time.time + delay;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (transform.position.y < collision.transform.position.y)
            {
                deadFXS.Play();
                enemyAnim.SetBool("isDead", true);
                enemyParticle.transform.position = transform.position;
                enemyParticle.Play();
                speed = 0;
            }
        }
    }
    public void DisableEnemy()
    {
        gameObject.SetActive(false);
    }
}
