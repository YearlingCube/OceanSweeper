using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Crate : MonoBehaviour
{
    // Declaring GameManager
    GameManager GM;

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
        Physics2D.IgnoreLayerCollision(6,6);
        GM = FindObjectOfType<GameManager>();
        ServeAngle = Random.Range(0, 360);
        // Server in a Random Direction
        Vector2 serveDirection = new Vector2(Mathf.Cos(ServeAngle * Mathf.Deg2Rad), Mathf.Sin(ServeAngle * Mathf.Deg2Rad));
        serveDirection.y = -serveDirection.y;
        velocity = serveDirection * Speed;
        this.transform.position = new Vector3(Random.Range(-9, 9), Random.Range(-4f, 3.54f), 0);
        GM.crateClickedCount = 0;
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
        // Mobile Inputs
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;
            if (touchPos == transform.position)
            {
                if (GM.FlagMode)
                {
                    SetFlag();
                }else
                {
                    Debug.Log("Touched, But how?");
                    Reveal();
                }
            }
        }
    }
    private void SetFlag()
    {
        // Changing if its a flag depending on Variable "isFlag"
        if (GM.BombCount - GM.FlagsClickedCount != 0)
        {
            isFlag = !isFlag;
            if (isFlag)
            {
                GM.FlagsClickedCount++;
            }
            else
            {
                GM.FlagsClickedCount--;
            }
            this.GetComponent<SpriteRenderer>().sprite = isFlag ? FlagSprite : CrateSprite;
        }
    }
    public void Reveal()
    {
        if (!isBomb)
        {
            this.GetComponent<SpriteRenderer>().sprite = EmptyCrateSprite;
            GM.crateClickedCount++;
            Debug.Log("crateClickedCount + 1 : " + GM.crateClickedCount);
            timer = Time.time + 5;
            destroy = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = BombSprite;
            GM.GamesCount++;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "BoarderSide")
        {
            SideBounce();
        } else if (collision.transform.tag == "BoarderTop")
        {
            TopBounce();
        }
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
