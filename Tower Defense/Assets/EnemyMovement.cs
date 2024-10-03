using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public List<GameObject> pathPositions;
    int currentIndex = 0;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (pathPositions[currentIndex].transform.position - transform.position).normalized * 1f;

        transform.rotation = Quaternion.LookRotation(Vector3.forward, rb.velocity);
        if(Vector2.Distance(pathPositions[currentIndex].transform.position, transform.position) < 0.2)
        {
            currentIndex++;

            if(currentIndex == pathPositions.Count)
            {
                Destroy(gameObject);
            }
        }
    }
}
