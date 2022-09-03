using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Crate : MonoBehaviour
{
    /*
        Keeps Track Of Everthing To Do With The Crates.
     */
    // Declaring GameManager
    GameManager GM;
    SoundManager SM;

    // Declaring Variables
    public Rigidbody2D rb;

    public BoxCollider2D SpawnArea;
    public Vector2 velocity { get; private set; } 
    [SerializeField] private float Speed = 1f;
    [SerializeField] private float ServeAngle;
    [SerializeField] private float offSet;

    public Sprite FlagSprite;
    public Sprite BombSprite;
    public Sprite EmptyCrateSprite;
    public Sprite CrateSprite;

    public bool isFound = false;
    public bool isBomb = false;
    public bool isFlag = false;


    bool destroy = false;
    float timer = 0;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(6,6);
        GM = FindObjectOfType<GameManager>();
        SM = FindObjectOfType<SoundManager>();
        SpawnArea = FindObjectOfType<CrateSpawnBoundsVisulizer>().GetComponent<BoxCollider2D>();
        ServeAngle = Random.Range(0, 360);

        // Server in a Random Direction
        Vector2 serveDirection = new Vector2(Mathf.Cos(ServeAngle * Mathf.Deg2Rad), Mathf.Sin(ServeAngle * Mathf.Deg2Rad));
        serveDirection.y = -serveDirection.y;
        velocity = serveDirection * Speed;
        this.transform.position = new Vector3(Random.Range(SpawnArea.bounds.min.x, SpawnArea.bounds.max.x), Random.Range(SpawnArea.bounds.min.y, SpawnArea.bounds.max.y), 0);
        GM.crateClickedCount = 0;
    }
    private void FixedUpdate()
    {
        // Setting Velocity
        rb.velocity = velocity;
    }
    void Update()
    {
        if (timer < Time.time && destroy)
        {
            Destroy(gameObject);
        }

        // Keeps Speed Above a Certain Level
        if (rb.velocity.x < Speed)
            rb.velocity = new Vector2(Speed,rb.velocity.y);
        if (rb.velocity.y < Speed)
            rb.velocity = new Vector2(rb.velocity.x, Speed);
    }
    private void SetFlag()
    {
        // Changing if its a flag depending on Variable "isFlag"
        SM.PlaySound("PlaceFlag");
        if (isFlag)
        {
            GM.FlagsClickedCount--;
            isFlag = !isFlag;
        }
        else if(isFlag == false)
        {
            if (GM.BombCount - GM.FlagsClickedCount != 0)
            {
                GM.FlagsClickedCount++;
                isFlag = !isFlag;
            }
        }
        this.GetComponent<SpriteRenderer>().sprite = isFlag ? FlagSprite : CrateSprite;
    }
    public void Reveal()
    {
        if (!isBomb)
        {
            SM.PlaySound("OpenCrate");
            this.GetComponent<SpriteRenderer>().sprite = EmptyCrateSprite;
            GM.crateClickedCount++;
            Debug.Log("crateClickedCount + 1 : " + GM.crateClickedCount);
            timer = Time.time + 5;
            destroy = true;
        }
        else
        {
            SM.PlaySound("CrateExplosion");
            this.GetComponent<SpriteRenderer>().sprite = BombSprite;
            GM.GameOver();
        }


    }
    private void SideBounce()
    {
        if (velocity.y < 0)
            offSet = -offSet;
        velocity = new Vector2(-velocity.x, velocity.y);
    }
    private void TopBounce()
    {
        if (velocity.x < 0)
            offSet = -offSet;
        velocity = new Vector2(velocity.x, -velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "BoarderSide")
        {
            SideBounce();
        } else if (collision.transform.tag == "BoarderTop")
        {
            TopBounce();
        }
        if (collision.transform.tag == "Boarder")
            velocity = new Vector2(-velocity.x, -velocity.y);
    }
    private void OnMouseOver()
    {
        // PC Inputs:
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