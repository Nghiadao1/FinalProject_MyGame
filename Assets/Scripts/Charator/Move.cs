using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public void Jump(float jumpForce, Rigidbody2D _rb)
    {
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    public void MoveLeft(float speed, Rigidbody2D _rb)
    {
        _rb.velocity = Vector3.left * speed * Time.deltaTime;
    }
    public void MoveRight(float speed, Rigidbody2D _rb)
    {
        _rb.velocity =Vector3.right * speed * Time.deltaTime;
    }
}
