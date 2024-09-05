using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public void Jump(float jumpForce, Rigidbody2D _rb)
    {
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
