using UnityEngine;

[CreateAssetMenu(fileName = "New Spawner", menuName = "Spawner")]
public class SpawnerData : ScriptableObject
{
    public EnemyData m_Animator;
    public int m_Max;
    public int m_NumberOfSpawn;
    public float m_SpawnCD;
    public float m_StartTime;
    public float m_Duration;
}
