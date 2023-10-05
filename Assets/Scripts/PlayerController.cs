using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float m_speed;
	private int m_heart;
	private bool m_FacingRight = true;
	private LevelSystem levelSystem;
	private PlayerSkills playerSkills;
	private void Awake()
    {
		levelSystem = new LevelSystem();
		playerSkills = new PlayerSkills();
		levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
		playerSkills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;
	}

	private void PlayerSkills_OnSkillUnlocked(object sender, PlayerSkills.OnSkillUnlockedEventArgs e)
	{
		switch (e.skillType)
		{
			case PlayerSkills.SkillType.MoveSpeed_1:
				SetMovementSpeed(65f);
				break;
			case PlayerSkills.SkillType.MoveSpeed_2:
				SetMovementSpeed(80f);
				break;
			case PlayerSkills.SkillType.HealthMax_1:
				IncreaseHeart(1);
				break;
			case PlayerSkills.SkillType.HealthMax_2:
				IncreaseHeart(2);
				break;
		}
	}

	private void LevelSystem_OnLevelChanged(object sender, EventArgs e)
	{
		//PlayAnimation

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

	private void SetMovementSpeed(float speed)
    {
		m_speed = speed;
    }
	private void IncreaseHeart(int amount)
    {
		m_heart += amount;
    }
}
