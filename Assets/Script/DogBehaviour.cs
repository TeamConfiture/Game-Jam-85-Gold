using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class DogBehaviour : MonoBehaviour
{
    public Vector3 position;
    public Vector3 target;
    
    public int direction = 0; // 0: SW, 1: SE, 2: NW, 3: NE
    private float waitEndAnim = 0;
    private GameObject anim;
    private bool isStopped = true;

    public Tilemap tilemap;


    // Start is called before the first frame update
    void Start()
    {
        position.x = transform.position.x;
        position.y = transform.position.y;
        position.z = 0.45f;
        target = position;
        anim = gameObject.transform.Find("Dog_sit_SW").gameObject;
        anim.SetActive(true);

    }

    void ChangeAnim(string AnimName)
    {
        anim.SetActive(false);
        anim = gameObject.transform.Find(AnimName).gameObject;
        anim.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (waitEndAnim == 0)
        {
            if(target != position)
            {
                position = target;
            }
            if (Input.GetMouseButtonDown(0)) // on left click
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float x = worldPosition.x, y = worldPosition.y;
                
                

                if (x < position.x && y < position.y) // SW
                {
                    target.x -= 0.8f;
                    target.y -= 0.4f;
                    direction = 0;
                    ChangeAnim("Dog_walk_SW");
                    Debug.Log("SW");
                }
                else if (x > position.x && y < position.y) // SE
                {
                    target.x += 0.8f;
                    target.y -= 0.4f;
                    direction = 1;
                    ChangeAnim("Dog_walk_SE");
                    Debug.Log("SE");
                }
                else if (x < position.x && y > position.y) // NW
                {
                    target.x -= 0.8f;
                    target.y += 0.4f;
                    direction = 2;
                    ChangeAnim("Dog_walk_NW");
                    Debug.Log("NW");
                }
                else if (x > position.x && y > position.y) // NE
                {
                    target.x += 0.8f;
                    target.y += 0.4f;
                    direction = 3;
                    ChangeAnim("Dog_walk_NE");
                    Debug.Log("NE");
                }
                /*Vector3Int nextCell = tilemap.WorldToCell(target);
                nextCell.y += 1;
                nextCell.z = 2;
                while (!tilemap.HasTile(nextCell))
                {
                    nextCell.z--;
                }
                Debug.Log("nextcell z " + nextCell.z);
                int currentz = -(int)((0.45f - position.z) / 0.1f);
                Debug.Log("currentz " + currentz);
                Debug.Log("y diff " + 0.1f * (currentz - nextCell.z));
                target.y -= 0.1f * (currentz - nextCell.z);
                target.z = 0.45f + 0.1f * nextCell.z;
                Debug.Log("target z " + target.z);    */
                waitEndAnim = 0.5f;
                isStopped = false;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Vector3Int digHere = tilemap.WorldToCell(position);
                //digHere.x += 1;
                digHere.y += 1;
                digHere.z = 2;
                Debug.Log(position);
                switch (direction)
                {
                    case 0:
                        ChangeAnim("Dog_dig_SW");
                        digHere.x--;
                        Debug.Log(digHere);
                        break;
                    case 1:
                        digHere.y--;
                        ChangeAnim("Dog_dig_SE");
                        Debug.Log(digHere);
                        break;
                    case 2:
                        ChangeAnim("Dog_dig_NW");
                        Debug.Log(digHere);
                        digHere.y++;
                        break;
                    case 3:
                        ChangeAnim("Dog_dig_NE");
                        Debug.Log(digHere);
                        digHere.x++;
                        break;
                    default:
                        Debug.Log("wtfff");
                        return;
                }
                while (!tilemap.HasTile(digHere) && digHere.z > -4)
                {
                    digHere.z--;
                }
                tilemap.SetTile(digHere, null);
                waitEndAnim = 0.5f;
                isStopped = false;
            } else
            {
                if (!isStopped)
                {
                    switch (direction)
                    {
                        case 0:
                            ChangeAnim("Dog_sit_SW");
                            break;
                        case 1:
                            ChangeAnim("Dog_sit_SE");
                            break;
                        case 2:
                            ChangeAnim("Dog_sit_NW");
                            break;
                        case 3:
                            ChangeAnim("Dog_sit_NE");
                            break;
                        default:
                            Debug.Log("wtfff");
                            return;
                    }
                    isStopped = true;
                }
            }
        }
       
            
        float progress = 1f - (waitEndAnim/0.5f);
        Vector3 realPos = progress * target + (1- progress) * position;

        
        transform.position = realPos;
        waitEndAnim -= Time.deltaTime;
        waitEndAnim = Mathf.Max(0, waitEndAnim);

    }
}
