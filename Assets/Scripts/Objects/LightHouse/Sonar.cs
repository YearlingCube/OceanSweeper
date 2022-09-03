using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sonar : MonoBehaviour
{
    /*
        This Script Takes Care Of The Sonar On The LightHouses.
        This Script Checks For Bombs In Crates And Will Display A Number Telling How Many Bombs Are Around It.
     */
    public TextMeshProUGUI NumberText;
    public int num = 0;
    public float Timer;

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<SpriteRenderer>().sprite.name == "Sonar2_0")
        {
            NumberText.text = num.ToString();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Crate")
        {
            if (collision.GetComponent<Crate>().isBomb)
            {
                num++;
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Crate")
        {
            if (collision.GetComponent<Crate>().isBomb)
            {
                num--;
            }
        }
    }
}
