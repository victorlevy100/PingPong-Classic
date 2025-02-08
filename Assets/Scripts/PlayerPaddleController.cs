using UnityEngine;

public class PlayerPaddleController : MonoBehaviour
{
    public float speed = 10.0f;
    public bool isPlayer1 = true;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        if (isPlayer1)
        {
            spriteRenderer.color = SaveController.GetInstance().colorPlayer;
        }
        else
        {
            spriteRenderer.color = SaveController.GetInstance().colorEnemy;
        }
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");

        //Calculate the new position of the paddle
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;
        
        //Limit the paddle movement to the screen
        newPosition.y = Mathf.Clamp(newPosition.y, -4f, 4f);

        transform.position = newPosition;
    }
}
