using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 1f, JumpHeight = 5f, Deceleration = 0.1f;
    public Rigidbody2D Rb;
    public bool Grounded;
    public Transform PT;
    public BoxCollider2D BC;

    private void LateUpdate()
    {
    }

    private void Update()
    {
        Move();
    }

    void Move() 
    {
        var k = Keyboard.current;

        if(k == null)
            return;

        if(k.spaceKey.wasPressedThisFrame)
        {
            Jump();
        }

        float x = (k.dKey.isPressed ? 1 : 0) - (k.aKey.isPressed ? 1 : 0);
        float move = MoveSpeed * x;

        if(move != 0) //move player
        Rb.linearVelocityX = move;

        //otherwise decelerate player
        float newX = Mathf.MoveTowards(Rb.linearVelocityX, 0, Deceleration * Time.deltaTime);
        Rb.linearVelocityX = newX;

    }

    void Jump()
    {
        int groundLayer = LayerMask.GetMask("Ground");
        int wallLayer = LayerMask.GetMask("Wall");

        //RaycastHit2D hit = Physics2D.Raycast(PT.position, Vector2.down, 1.1f, groundLayer);
        //Debug.Log(hit.collider);

        //if (hit.collider.CompareTag("Ground"))
        //{
        //    Rb.linearVelocityY = JumpHeight;
        //}


        if (BC.IsTouchingLayers(groundLayer))
        {
            //Rb.linearVelocityY = JumpHeight;
            Rb.AddForceY(JumpHeight, ForceMode2D.Impulse);
        }
        
    }
}
