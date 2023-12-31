using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem
{

    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private int level;
    private int experience;

    public LevelSystem()
    {
        level = 0;
        experience = 0;
    }

    public void AddExperience(int amount)
    {
            experience += amount;
            while (experience >= GetExperienceToNextLevel(level))
            {
                // Enough experience to level up
                experience -= GetExperienceToNextLevel(level);
                level++;
                if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
            }
            if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
    }

    public int GetLevelNumber()
    {
        return level;
    }

    public float GetExperienceNormalized()
    {
        return (float)experience / GetExperienceToNextLevel(level);
    }

    public int GetExperience()
    {
        return experience;
    }

    public int GetExperienceToNextLevel(int level)
    {
        if (level < 20)
        {
            return (level + 1) * 10 - 5;
        }
        else if (level >= 20 && level < 40)
        {
            return (level + 1) * 13 - 6;
        }
        else
        {
            return (level + 1) * 16 - 8;
        }
    }

}
