using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    //private GameObject enemy;
    private GameObject[] enemies;
    [SerializeField]
    private float profectileForce = 15f;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDistance = 11f;
        Vector3 direction = transform.position;
        
        for (int foe = 0; foe < enemies.Length; foe++)
        {
            float distance = Vector2.Distance(transform.position, enemies[foe].transform.position);
            if (distance < minDistance)
            {
                direction = enemies[foe].transform.position - transform.position;
                minDistance = distance;
            }
        }

        
        rb.velocity = new Vector2(direction.x, direction.y).normalized * profectileForce;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
