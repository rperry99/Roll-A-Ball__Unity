using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; // For TextMeshPro

public class PlayerController : MonoBehaviour
{
    // Assign a new Rigidbody variable
    private Rigidbody rb;

    // Create a coutner for points
    private int count;

    // Variable for the win text
    public GameObject winTextObject;


    // Movement along the X and Y axes.
    private float movementX;
    private float movementY;

    // Speed at which the player moves.
    public float speed = 0;

    // Declare the text variable
    public TextMeshProUGUI countText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        // Set the movement vector
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Collected: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

}
