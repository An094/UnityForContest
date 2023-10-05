using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform m_FirePoint;
    public float m_BulletForce;
    public float m_FireRate = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds wait = new WaitForSeconds(m_FireRate);
        while (true)
        {
            yield return wait;
            GameObject bullet = ObjectPooler.Instance.SpawnFromPool("Bullet", m_FirePoint.position, m_FirePoint.rotation);
            bullet.SetActive(true);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(m_FirePoint.right * m_BulletForce, ForceMode2D.Impulse);
        }

    }


}
