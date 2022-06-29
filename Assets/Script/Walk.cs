using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float speed = 3.0f; // для контроля скорости нашего персонажа 
    public float jumpForce = 6.0f; // а тут прыжок 
    private Rigidbody2D rigidbod; // физический компонет для прыжка 
    public Animator animator; // анимация персонажа 
    private SpriteRenderer sprite; // он отвечает за картинку 
    private bool Ground = false; // он будет помогать нам проверять на земле ли мы находимся 

    // Start is called before the first frame update
    void Start()
    {
        rigidbod = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Run()
    {
        Vector3 direction = this.transform.right * Input.GetAxis("Horizontal");
        //GetAxis - это оси, виртуальные оси: гориз-ал, вертикальная, профильная 
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0f; 

    }
     
    void Jump()
    {
        rigidbod.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        animator.SetTrigger("Jump");
    }

    void CheckGround() // проверка на земле ли наш персонаж 
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 1.3f);
        Ground = colliders.Length > 1;
    }

    void FixedUpdate()
    {
        CheckGround(); 
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (Ground && Input.GetKeyDown(KeyCode.Space))
            Jump();
        if (Input.GetKeyDown(KeyCode.Mouse0))
            animator.SetTrigger("Attack");
    }
}
