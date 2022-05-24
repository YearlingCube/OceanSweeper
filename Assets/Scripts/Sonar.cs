using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sonar : MonoBehaviour
{
    public TextMeshProUGUI NumberText;
    public int num = 0;
    public float Timer;

    // This bool is for checking if Sonar is in the radius of another Sonar
    public bool InRadius = false;

    //float Radius = 0.4202043f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
    }
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Sonar")
        {

           InRadius = true;
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
        if (collision.tag == "Sonar")
        {
            InRadius = false;
        }
    }
}
