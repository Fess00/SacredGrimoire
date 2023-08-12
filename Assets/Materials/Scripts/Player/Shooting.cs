using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint;
    [SerializeField] 
    private GameObject projectile;
    private float timer;
    private GameObject[] enemies;

    void Start()
    {
        enemies = new GameObject[15];
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach (var enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < 10 && timer > 2)
            {
                timer = 0;
                Shoot();
                break;
            }
        }

        
    }

    private void Shoot()
    {
        Instantiate(projectile, firePoint.position, Quaternion.identity);
    }
    
    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     if (timer > 2 && other.gameObject.CompareTag("Enemy"))
    //     {
    //         timer = 0;
    //         Shoot();
    //     }
    // }
}
