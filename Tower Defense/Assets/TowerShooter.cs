using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class TowerShooter : MonoBehaviour
{
    public List<GameObject> enemyTargets = new List<GameObject>();
    public GameObject bulletPrefab;

    public GameObject gun;

    float cooldown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if(enemyTargets.Count> 0 && cooldown <= 0)
        {
            Vector2 shootDirection = enemyTargets[0].transform.position - transform.position;
            //gun.transform.rotation = Quaternion.LookRotation(Vector3.forward, shootDirection);

            float angle = Vector2.SignedAngle(Vector2.up, shootDirection);
            gun.transform.rotation = Quaternion.Euler(0, 0, angle);
            if(cooldown <= 0f)
            {
               

                GameObject bullet = Instantiate(bulletPrefab, (Vector2)transform.position + shootDirection.normalized * 1.5f, Quaternion.identity);


                bullet.GetComponent<Rigidbody2D>().velocity = shootDirection.normalized * 10f;

                cooldown = 1f;
            }

           
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<EnemyMovement>() != null)
        {
            enemyTargets.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>() != null)
        {
            enemyTargets.Remove(collision.gameObject);
        }
    }
}
