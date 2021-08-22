using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Sprite walkingSprite;
    public Sprite idleSprite;

    private float airSpeedMultiplier = .3f;
    private Rigidbody2D body2D;
    private SpriteRenderer renderer2D;

    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var forceX = 0f;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            var newSpeed = speed;

            forceX = newSpeed * airSpeedMultiplier;
            renderer2D.sprite = walkingSprite;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            var newSpeed = -speed;

            forceX = newSpeed * airSpeedMultiplier;
            renderer2D.sprite = walkingSprite;
            transform.rotation = new Quaternion(0, -180, 0, 0);
        }
        else
        {
            renderer2D.sprite = idleSprite;
        }
        
        body2D.AddForce(new Vector2(forceX, 0));
    }
}
