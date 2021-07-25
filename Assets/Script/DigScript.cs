using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DigScript : MonoBehaviour
{
    public Tilemap tilemap;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
            Vector3Int position = tilemap.WorldToCell(worldPoint);
            while (!tilemap.HasTile(position) && position.z > -4 )
            {
                position.z--;
            }
            tilemap.SetTile(position, null);
        }
    }
}
