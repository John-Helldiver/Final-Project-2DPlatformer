using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float playerSpeed = 3f;
    public bool gravInvert = false;
    public float gravScale = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f;
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            moveX = 1f;
        }
        else if (Keyboard.current.leftArrowKey.isPressed)
        {
            moveX = -1f;
        }

        if (Keyboard.current.upArrowKey.isPressed && gravInvert == false)
        {
            gravInvert = true;
            rb.gravityScale = gravScale * -1f;
        }

        if (Keyboard.current.downArrowKey.isPressed && gravInvert == true)
        {
            gravInvert = false;
            rb.gravityScale = gravScale;
        }

        rb.linearVelocity = new Vector2(moveX * playerSpeed, rb.linearVelocity.y);
    }
    
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Hazard"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}
