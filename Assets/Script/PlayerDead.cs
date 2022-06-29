using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public GameObject enemy;
    public int health = 2;
    private Animator animator;
    private AudioSource au;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        au = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            health -= 1;
        }
        if (health <= 0)
        {
            animator.SetTrigger("Dead");
            Destroy(this.gameObject, 0.6f);
            au.Play();
        }
    }

}
