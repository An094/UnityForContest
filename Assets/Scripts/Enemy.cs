using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject m_AimingSprite;
    private bool isTargeted;
    public bool IsTargeted
    {
        get => isTargeted;
        set
        {
            isTargeted = value;
            m_AimingSprite.SetActive(value);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isTargeted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
