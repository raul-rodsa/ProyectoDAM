using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling } //Para los estados de movimiento

    //Fuentes de audio
    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Movimiento básico horizontal
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        //Edit > Project Settings > InputManager > Axis
        //En cada tecla se puede personalizar el nombre como el de a continuación:
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x , jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state; //Clase enum
        //Animación para correr
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
            Debug.Log("ASA");
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true; //Se voltea cuando anda hacia atrás
            Debug.Log("UWU");
        }
        else
        {
            state = MovementState.idle;

        }

        //SALTO
        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }else if(rb.velocity.y < -.1f)
        {
            state= MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        //Devuelve true o false dependiendo si estamos tocando el suelo o no
        //Para esto hemos creado un anueva Layer en Terrain llamada Ground
        //Y la seleccionamos para aquí desde Unity en la pestaña de player en "Jumpable Ground"

        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        
    }
}
