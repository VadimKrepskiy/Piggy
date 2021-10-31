using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Vector2[] _childrenPositions;
    [SerializeField] Vector2[] _thisColliderSizes, _thisColliderOffsets;

    [SerializeField] protected Sprite[] _sprites;

    protected SpriteRenderer _topSpriteRenderer, _bottomSpriteRenderer;
    protected Vector2 _direction;

    private BoxCollider2D _thisCollider, _bottomCollider;
    private int _sortingOrder;

    public bool OnMove { get; private set; } = false;
    public bool IsCanMove { get; private set; } = true;
    public bool IsDamaged { get; private set; }

    protected virtual void Awaken()
    {
        
    }

    protected virtual void Start()
    {
        IsDamaged = false;
        _topSpriteRenderer = transform.Find("Top").GetComponent<SpriteRenderer>();
        _thisCollider = GetComponent<BoxCollider2D>();
        _bottomSpriteRenderer = transform.Find("Bottom").GetComponent<SpriteRenderer>();
        _bottomCollider = _bottomSpriteRenderer.transform.GetComponent<BoxCollider2D>();
        _sortingOrder = _bottomSpriteRenderer.sortingOrder;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Barrier")
            IsCanMove = false;
        if (collision.tag == "Hiding")
            _bottomSpriteRenderer.sortingOrder = collision.GetComponent<SpriteRenderer>().sortingOrder - 1;
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Barrier")
            IsCanMove = false;
        if (collision.tag == "Hiding")
            _bottomSpriteRenderer.sortingOrder = collision.GetComponent<SpriteRenderer>().sortingOrder - 1;
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Barrier")
            IsCanMove = true;
        if (collision.tag == "Hiding")
            _bottomSpriteRenderer.sortingOrder = _sortingOrder;
    }

    public void Damaged()
    {
        IsDamaged = true;
    }

    public virtual void Move()
    {
        transform.position += (Vector3)_direction * _speed * Time.deltaTime;
    }

    public virtual void Turn(string direction)
    {
        switch(direction)
        {
            case "R":
                {
                    _direction = Vector2.right;
                    _topSpriteRenderer.sprite = _sprites[0];
                    _topSpriteRenderer.transform.localPosition = _childrenPositions[0];
                    _thisCollider.size = _thisColliderSizes[0];
                    _thisCollider.offset = _thisColliderOffsets[0];
                    _bottomSpriteRenderer.sprite = _sprites[4];
                    _bottomSpriteRenderer.transform.localPosition = _childrenPositions[4];
                    OnMove = true;
                    break;
                }
            case "L":
                {
                    _direction = Vector2.left;
                    _topSpriteRenderer.sprite = _sprites[1];
                    _topSpriteRenderer.transform.localPosition = _childrenPositions[1];
                    _thisCollider.size = _thisColliderSizes[1];
                    _thisCollider.offset = _thisColliderOffsets[1];
                    _bottomSpriteRenderer.sprite = _sprites[5];
                    _bottomSpriteRenderer.transform.localPosition = _childrenPositions[5];
                    OnMove = true;
                    break;
                }
            case "D":
                {
                    _direction = new Vector2(-0.125f, -1f);
                    _topSpriteRenderer.sprite = _sprites[2];
                    _topSpriteRenderer.transform.localPosition = _childrenPositions[2];
                    _thisCollider.size = _thisColliderSizes[2];
                    _thisCollider.offset = _thisColliderOffsets[2];
                    _bottomSpriteRenderer.sprite = _sprites[6];
                    _bottomSpriteRenderer.transform.localPosition = _childrenPositions[6];
                    OnMove = true;
                    break;
                }
            case "U":
                {
                    _direction = new Vector2(0.125f, 1f);
                    _topSpriteRenderer.sprite = _sprites[3];
                    _topSpriteRenderer.transform.localPosition = _childrenPositions[3];
                    _thisCollider.size = _thisColliderSizes[3];
                    _thisCollider.offset = _thisColliderOffsets[3];
                    _bottomSpriteRenderer.sprite = _sprites[7];
                    _bottomSpriteRenderer.transform.localPosition = _childrenPositions[7];
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

