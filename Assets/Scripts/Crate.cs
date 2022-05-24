using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Crate : MonoBehaviour
{
    // Declaring GameManager
    public GameManager GM;

    // Declaring Variables
    public Rigidbody2D rb;
    public Vector2 velocity { get; private set; } 
    [SerializeField] private float Speed = 1f;
    [SerializeField] private float ServeAngle;

    public Sprite FlagSprite;
    public Sprite BombSprite;
    public Sprite EmptyCrateSprite;
    public Sprite CrateSprite;

    public bool isFound = false;
    public bool isBomb = false;
    public bool isFlag = false;

    bool destroy = false;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        ServeAngle = Random.Range(0, 360);
        // Server in a Random Direction
        Vector2 serveDirection = new Vector2(Mathf.Cos(ServeAngle * Mathf.Deg2Rad), Mathf.Sin(ServeAngle * Mathf.Deg2Rad));
        serveDirection.y = -serveDirection.y;
        velocity = serveDirection * Speed;
        this.transform.position = new Vector3(Random.Range(-9, 9), Random.Range(-4.75f, 4.75f), 0);
    }
    private void FixedUpdate()
    {
        // Setting Velocity
            rb.velocity = velocity;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer < Time.time && destroy)
        {
            Destroy(gameObject);
        }
    }
    private void SetFlag()
    {
        // Changing if its a flag depending on Variable "isFlag"
        isFlag = !isFlag;
        
        this.GetComponent<SpriteRenderer>().sprite = isFlag ? FlagSprite : CrateSprite;
    }
    private void Reveal()
    {
        if (!isBomb)
        {
            this.GetComponent<SpriteRenderer>().sprite = EmptyCrateSprite;
            timer = Time.time + 5;
            destroy = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = BombSprite;
            GM.GameOver();
        }

    }
    private void SideBounce()
    {
        velocity = new Vector2(-velocity.x, velocity.y);
    }
    private void TopBounce()
    {
        velocity = new Vector2(velocity.x, -velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BoarderSide")
        {
            SideBounce();
        } else if (collision.tag == "BoarderTop")
        {
            TopBounce();
        }
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Reveal();
        }
        if (Input.GetMouseButtonDown(1))
        {
            SetFlag();
        }
    }
}
