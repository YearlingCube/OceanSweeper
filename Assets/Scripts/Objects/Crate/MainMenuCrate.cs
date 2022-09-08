using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCrate : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;
    public Transform Spawn;

    public Transform target { get; private set; }

    public float speed;
    float step = 0;



    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;
        if (transform.position == pos1.position)
            target = pos2;
        else if (transform.position == pos2.position)
            target = pos3;
        else if (transform.position == pos3.position)
            target = pos4;
        else if (transform.position == pos4.position)
            target = pos5;
        else if (transform.position == pos5.position)
        {
            transform.position = Spawn.position;
            target = pos1;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, step);

    }
}
