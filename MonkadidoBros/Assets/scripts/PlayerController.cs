using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 1f, JumpHeight = 5f, Gravity = -9.81f;
    public Rigidbody2D rb;
    public bool grounded;

    private void Update()
    {
        Move();
    }

    void Move() 
    {
        var k = Keyboard.current;

        if(k == null)
            return;

        float x = (k.dKey.isPressed ? 1 : 0) - (k.aKey.isPressed ? 1 : 0);
        float move = MoveSpeed * x;

        rb.linearVelocityX = move;
    }

    void Jump()
    {

    }
}
