using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LightningScript : MonoBehaviour
{
    float speed;
    float time;
    Grid m_grid;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        speed = 4.0f;
    }

    void setUp(GameObject grid){
        m_grid = grid.GetComponent<Grid>();
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        transform.position += transform.right * speed * Time.deltaTime;

        Vector3Int myCellpos = myGrid.WorldToCell(transform.position);

        if (m_grid.GetComponent<Tilemap>().HasTile(myCellpos))
        {
            GameObject tilehere = m_grid.GetComponent<Tilemap>().GetTile(myCellpos);
            
        if(tilehere.GetComponent("LightningEffected")){
            tilehere.GetComponent<LightningEffected>().Toggle();
        }

        }
        
    }


    
}
