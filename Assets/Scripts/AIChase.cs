using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    private GameObject m_player;
    public float m_speed;
    private bool m_FacingRight = true;
    // Update is called once per frame
    private void Start()
    {
        m_player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        float distance = Vector2.Distance(m_player.transform.position, transform.position);
        Vector2 direction = m_player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(direction.x < 0 && m_FacingRight || direction.x > 0 && !m_FacingRight)
        {
            Flip();
        }
        transform.position = Vector2.MoveTowards(transform.position, m_player.transform.position, m_speed * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(Vector2.forward * angle);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
