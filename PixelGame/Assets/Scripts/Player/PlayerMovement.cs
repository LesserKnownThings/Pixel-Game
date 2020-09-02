using Assets.Scripts.Misc;
using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb { get => GetComponent<Rigidbody2D>(); }
    private Animator anim { get => GetComponent<Animator>(); }

    public LayerMask layer;
    public HealthControll healthControll;

    private void Start()
    {
        rb.gravityScale = 15f;
        GlobalVariables.CollectedFruits = 0;
    }
    private void Update()
    {
        Debug.Log(GlobalVariables.CollectedFruits);

        var isDead = PlayerStats.playerLives <= 0;

        if (isDead)
            Die();

        var isFalling = !PlayerRaycast.Ray(transform, layer);

        var h = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(h * Time.deltaTime * speed, 0, 0);

        SetAnimations(h, isFalling);
        ChangeDirection();
        Jump(isFalling);


        if(GlobalVariables.CollectedFruits == GlobalVariables.MaxMelons)
        {
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("Manager").GetComponent<DisplayMessage>().WinMessage();
        }
    }

    private void Jump(bool isFalling)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isFalling)
            {
                rb.AddForce(Vector2.up * 1850, ForceMode2D.Impulse);
            }
        }
    }
    public void GetHit()
    {
        anim.SetTrigger("Hit");
        healthControll.DestroyHealth();
    }

    public void Die()
    {
        GameObject.FindGameObjectWithTag("Manager").GetComponent<DisplayMessage>().LoseMessage();
        Destroy(gameObject);
    }
    private void ChangeDirection()
    {
        if (Input.GetKeyDown(KeyCode.D))
            transform.localScale = new Vector3(1, 1, 1);
        else if (Input.GetKeyDown(KeyCode.A))
            transform.localScale = new Vector3(-1, 1, 1);
    }
    private void SetAnimations(float h, bool isFalling)
    {
        anim.SetFloat("Run", Mathf.Abs(h));
        anim.SetBool("Falling", isFalling);
               
    }
}
