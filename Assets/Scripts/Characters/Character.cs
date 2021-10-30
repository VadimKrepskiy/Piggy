using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Sprite[] sprites;
    [SerializeField] Vector2[] childrenPositions;
    [SerializeField] Vector2[] thisColliderSizes, bottomColliderSizes, thisColliderOffsets, bottomColliderOffsets;

    private Vector2 _direction;
    private SpriteRenderer _topSpriteRenderer, _bottomSpriteRenderer;
    private BoxCollider2D _thisCollider, _bottomCollider;
    private int _sortingOrder;

    public bool OnMove { get; private set; } = false;
    public bool IsCanMove { get; private set; } = true;

    protected virtual void Awaken()
    {
        
    }

    protected virtual void Start()
    {
        _topSpriteRenderer = transform.Find("Top").GetComponent<SpriteRenderer>();
        _thisCollider = GetComponent<BoxCollider2D>();
        _bottomSpriteRenderer = transform.Find("Bottom").GetComponent<SpriteRenderer>();
        _bottomCollider = _bottomSpriteRenderer.transform.GetComponent<BoxCollider2D>();
        _sortingOrder = _bottomSpriteRenderer.sortingOrder;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Barrier")
            IsCanMove = false;
        if (collision.tag == "Hiding")
            _bottomSpriteRenderer.sortingOrder = collision.GetComponent<SpriteRenderer>().sortingOrder - 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Barrier")
            IsCanMove = true;
        if (collision.tag == "Hiding")
            _bottomSpriteRenderer.sortingOrder = _sortingOrder;
    }

    public void Move()
    {
        transform.position += (Vector3)_direction * speed * Time.deltaTime;
    }

    public void Turn(string direction)
    {
        switch(direction)
        {
            case "R":
                {
                    _direction = Vector2.right;
                    _topSpriteRenderer.sprite = sprites[0];
                    _topSpriteRenderer.transform.localPosition = childrenPositions[0];
                    _thisCollider.size = thisColliderSizes[0];
                    _thisCollider.offset = thisColliderOffsets[0];
                    _bottomSpriteRenderer.sprite = sprites[4];
                    _bottomSpriteRenderer.transform.localPosition = childrenPositions[4];
                    OnMove = true;
                    break;
                }
            case "L":
                {
                    _direction = Vector2.left;
                    _topSpriteRenderer.sprite = sprites[1];
                    _topSpriteRenderer.transform.localPosition = childrenPositions[1];
                    _thisCollider.size = thisColliderSizes[1];
                    _thisCollider.offset = thisColliderOffsets[1];
                    _bottomSpriteRenderer.sprite = sprites[5];
                    _bottomSpriteRenderer.transform.localPosition = childrenPositions[5];
                    OnMove = true;
                    break;
                }
            case "D":
                {
                    _direction = Vector2.down;
                    _topSpriteRenderer.sprite = sprites[2];
                    _topSpriteRenderer.transform.localPosition = childrenPositions[2];
                    _thisCollider.size = thisColliderSizes[2];
                    _thisCollider.offset = thisColliderOffsets[2];
                    _bottomSpriteRenderer.sprite = sprites[6];
                    _bottomSpriteRenderer.transform.localPosition = childrenPositions[6];
                    OnMove = true;
                    break;
                }
            case "U":
                {
                    _direction = Vector2.up;
                    _topSpriteRenderer.sprite = sprites[3];
                    _topSpriteRenderer.transform.localPosition = childrenPositions[3];
                    _thisCollider.size = thisColliderSizes[3];
                    _thisCollider.offset = thisColliderOffsets[3];
                    _bottomSpriteRenderer.sprite = sprites[7];
                    _bottomSpriteRenderer.transform.localPosition = childrenPositions[7];
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
/*
 * using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Sprite[] sprites;
    [SerializeField] Vector2[] childrenPositions;
    [SerializeField] Vector2[] thisColliderSizes, bottomColliderSizes, thisColliderOffsets, bottomColliderOffsets;

    private Vector2 _direction;
    private SpriteRenderer _topSpriteRenderer, _bottomSpriteRenderer;
    private BoxCollider2D _thisCollider, _bottomCollider;

    public bool OnMove { get; private set; } = false;
    public bool IsCanMove { get; private set; } = true;

    protected virtual void Awaken()
    {
        
    }

    protected virtual void Start()
    {
        _topSpriteRenderer = transform.Find("Top").GetComponent<SpriteRenderer>();
        _thisCollider = GetComponent<BoxCollider2D>();
        _bottomSpriteRenderer = transform.Find("Bottom").GetComponent<SpriteRenderer>();
        _bottomCollider = _bottomSpriteRenderer.transform.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Barrier")
            IsCanMove = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Barrier")
            IsCanMove = true;
    }

    public void Move()
    {
        transform.position += (Vector3)_direction * speed * Time.deltaTime;
    }

    public void Turn(string direction)
    {
        switch(direction)
        {
            case "R":
                {
                    _direction = Vector2.right;
                    _topSpriteRenderer.sprite = sprites[0];
                    _topSpriteRenderer.transform.localPosition = childrenPositions[0];
                    _thisCollider.size = thisColliderSizes[0];
                    _thisCollider.offset = thisColliderOffsets[0];
                    _bottomSpriteRenderer.sprite = sprites[4];
                    _bottomSpriteRenderer.transform.localPosition = childrenPositions[4];
                    _bottomCollider.size = bottomColliderSizes[0];
                    _bottomCollider.offset = bottomColliderOffsets[0];
                    OnMove = true;
                    break;
                }
            case "L":
                {
                    _direction = Vector2.left;
                    _topSpriteRenderer.sprite = sprites[1];
                    _topSpriteRenderer.transform.localPosition = childrenPositions[1];
                    _thisCollider.size = bottomColliderSizes[1];
                    _thisCollider.offset = bottomColliderOffsets[1];
                    _bottomSpriteRenderer.sprite = sprites[5];
                    _bottomSpriteRenderer.transform.localPosition = childrenPositions[5];
                    _bottomCollider.size = bottomColliderSizes[1];
                    _bottomCollider.offset = bottomColliderOffsets[1];
                    OnMove = true;
                    break;
                }
            case "D":
                {
                    _direction = Vector2.down;
                    _topSpriteRenderer.sprite = sprites[2];
                    _topSpriteRenderer.transform.localPosition = childrenPositions[2];
                    _thisCollider.size = bottomColliderSizes[2];
                    _thisCollider.offset = bottomColliderOffsets[2];
                    _bottomSpriteRenderer.sprite = sprites[6];
                    _bottomSpriteRenderer.transform.localPosition = childrenPositions[6];
                    _bottomCollider.size = bottomColliderSizes[2];
                    _bottomCollider.offset = bottomColliderOffsets[2];
                    OnMove = true;
                    break;
                }
            case "U":
                {
                    _direction = Vector2.up;
                    _topSpriteRenderer.sprite = sprites[3];
                    _topSpriteRenderer.transform.localPosition = childrenPositions[3];
                    _thisCollider.size = bottomColliderSizes[3];
                    _thisCollider.offset = bottomColliderOffsets[3];
                    _bottomSpriteRenderer.sprite = sprites[7];
                    _bottomSpriteRenderer.transform.localPosition = childrenPositions[7];
                    _bottomCollider.size = bottomColliderSizes[3];
                    _bottomCollider.offset = bottomColliderOffsets[3];
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

 */
