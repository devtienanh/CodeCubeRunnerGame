using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpFore; //Lực nhảy
    Rigidbody2D m_rb; //Biến tham chiếu đến Rigidbody2D
    bool m_isGround;
    GameController m_gc;

    public AudioSource aus;
    public AudioClip jumpSound;
    public AudioClip loseSound;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }

     
    void Update()
    {
        if (m_gc.IsGameover()) // Kiểm tra trạng thái game over từ GameController
            return;
        //Nhảy
        bool isJumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
        if (isJumpKeyPressed && m_isGround)
        {
            //Vector2.up = (0, 1)
            m_rb.AddForce(Vector2.up * jumpFore);
            m_isGround = false; //Khi nhảy player k chạm đất
            if(aus && jumpSound)
            {
                aus.PlayOneShot(jumpSound);
            }
        }
    }
    public void Jump()
    {
        if(!m_isGround)
        {
            return;
        }    
        m_rb.AddForce(Vector2.up * jumpFore);
        m_isGround = false; //Khi nhảy player k chạm đất
        if (aus && jumpSound)
        {
            aus.PlayOneShot(jumpSound);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //Kiểm tra player chạm đất 
        if (col.gameObject.CompareTag("Ground"))
        {
            m_isGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Bắt va chạm giữa player với chướng ngại vật
        if (col.CompareTag("Obstacle"))
        {
            if (aus && loseSound && !m_gc.IsGameover())
            {
                aus.PlayOneShot(loseSound);
            }
            m_gc.SetGameoverState(true);
            //Debug.Log("Player đã va chạm chướng ngại vật, Game over");
        }
    }
}
