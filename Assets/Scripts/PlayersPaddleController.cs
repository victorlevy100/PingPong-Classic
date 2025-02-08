using UnityEngine;

public class PlayersPaddleController : MonoBehaviour
{
    public float speed = 10.0f;
    public KeyCode upKey = KeyCode.W; // Tecla para mover para cima
    public KeyCode downKey = KeyCode.S; // Tecla para mover para baixo

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
        float moveInput = 0f;

        if (Input.GetKey(upKey))
        {
            moveInput = 1f;
        }
        else if (Input.GetKey(downKey))
        {
            moveInput = -1f;
        }

        // Calcular a nova posição do paddle
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;

        // Limitar o movimento do paddle à tela
        newPosition.y = Mathf.Clamp(newPosition.y, -4.0f, 4.0f);

        transform.position = newPosition;
    }
}
