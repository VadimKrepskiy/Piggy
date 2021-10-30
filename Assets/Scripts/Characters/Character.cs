using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Sprite[] sprites;

    private Vector2 _direction;
    protected SpriteRenderer spriteRenderer;

    public bool OnMove { get; private set; } = false;

    public void Move()
    {
        transform.position += (Vector3)_direction*speed*Time.deltaTime;
    }

    public void Turn(string direction)
    {
        switch(direction)
        {
            case "R":
                {
                    _direction = Vector2.right;
                    spriteRenderer.sprite = sprites[0];
                    OnMove = true;
                    break;
                }
            case "L":
                {
                    _direction = Vector2.left;
                    spriteRenderer.sprite = sprites[1];
                    OnMove = true;
                    break;
                }
            case "D":
                {
                    _direction = Vector2.down;
                    spriteRenderer.sprite = sprites[2];
                    OnMove = true;
                    break;
                }
            case "U":
                {
                    _direction = Vector2.up;
                    spriteRenderer.sprite = sprites[3];
                    OnMove = true;
                    break;
                }
            case "N":
                {
                    OnMove = false;
                    break;
                }
        }
    }
}
