using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float m_speed;
	private bool m_FacingRight = true;
	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    public void Move(Vector2 _move)
    {
		if(_move.x < 0 && m_FacingRight || _move.x > 0 && !m_FacingRight)
        {
			Flip();
        }
		Vector3 scaledMovement = m_speed * Time.deltaTime * new Vector3(
			_move.x,
			_move.y,
			0
		);

		transform.Translate(scaledMovement);
	}
}
