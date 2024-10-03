using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject groundPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int x = -11; x < 12; x++)
        {
            for(int y = -6; y < 7; y++)
            {
                Instantiate(groundPrefab, new Vector2(x, y), Quaternion.identity, transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
