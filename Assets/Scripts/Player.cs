using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Set the Player Status and Behavior
/// </summary>
public class Player : MonoBehaviour
{

    Rigidbody2D m_rigid2D;

    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_runSpeed;
    [SerializeField] private float m_jumpPower;
    [SerializeField] private float m_SmoothTime;
    private Vector3 m_velocity = Vector3.zero;

    private bool m_canRun = false;
    float fTimeElapsed;
    // Start is called before the first frame update
    private void Awake()
    {
        m_rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            m_rigid2D.AddForce(new Vector2(0f, m_jumpPower));
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Attack 1");
        }
    }

    // FixedUpdate

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        Move(h, m_moveSpeed);

    }

    void Move(float move, float speed)
    {
        Vector2 targetVelocity = new Vector2(move * speed, m_rigid2D.velocity.y);
        m_rigid2D.velocity = Vector3.SmoothDamp(m_rigid2D.velocity, targetVelocity, ref m_velocity, m_SmoothTime);
    }


}
