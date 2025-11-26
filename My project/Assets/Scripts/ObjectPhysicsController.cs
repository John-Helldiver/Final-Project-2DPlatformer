using UnityEngine;

public class ObjectPhysicsController : MonoBehaviour
{
    Rigidbody2D childRB;
    PlayerController playerController;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.gravInvert == true)
        {
            foreach (Transform child in transform)
            {
                childRB = child.GetComponent<Rigidbody2D>();
                if (childRB != null)
                {
                    childRB.gravityScale = playerController.gravScale * -1f;
                }
            }
        } else 
        {
            foreach (Transform child in transform)
            {
                childRB = child.GetComponent<Rigidbody2D>();
                if (childRB != null)
                {
                    childRB.gravityScale = playerController.gravScale;
                }
            }
        }
    }
}
