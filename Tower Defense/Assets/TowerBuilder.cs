using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerBuilder : MonoBehaviour
{
    public GameObject towerPrefab;

    GameObject Indicator;

    public LayerMask buildLayer;

    // Start is called before the first frame update
    void Start()
    {
        Indicator = Instantiate(towerPrefab);
        Indicator.GetComponentInChildren<BoxCollider2D>().enabled = false;
        Indicator.GetComponent<CircleCollider2D>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 towerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        towerPos.x = Mathf.Round(towerPos.x);
        towerPos.y = Mathf.Round(towerPos.y);


        Indicator.transform.position = new Vector3(towerPos.x, towerPos.y, -3);

        if (Physics2D.OverlapCircle(towerPos, 0.25f, buildLayer)){
            Indicator.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            return;
        }
        else
        {
            Indicator.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            

            Instantiate(towerPrefab, towerPos, Quaternion.identity);
        }
    }
}
