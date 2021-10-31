using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] string[] route;

    public bool IsPlayerFound { get; private set; }
    public VisibilityController _visibilityController;

    private EnemyStateMachine _stateMachine;
    private int _index = 1;

    protected override void Awaken()
    {
        base.Awaken();
        _index = 1;
        Turn(route[_index - 1]);
        IsPlayerFound = false;
        
        _stateMachine = GetComponent<EnemyStateMachine>();
    }

    protected override void Start()
    {
        base.Start();
        _visibilityController = transform.Find("Visibility").GetComponent<VisibilityController>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.tag == "Player")
            IsPlayerFound = true;
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        if (collision.tag == "Player")
            IsPlayerFound = false;
    }

    public void CheckDestination()
    {
        bool isReached = false;
        float value = float.Parse(route[_index], CultureInfo.InvariantCulture);
        switch (route[_index-1])
        {
            case "R":
                {
                    if (transform.position.x >= value)
                        isReached = true;
                    break;
                }
            case "L":
                {
                    if (transform.position.x <= value)
                        isReached = true;
                    break;
                }
            case "D":
                {
                    if (transform.position.y <= value)
                        isReached = true;
                    break;
                }
            case "U":
                {
                    if (transform.position.y >= value)
                        isReached = true;
                    break;
                }
        }

        if (isReached)
        {
            if (_index < route.Length - 2)
                _index += 2;
            else _index = 1;
            Turn(route[_index - 1]);
        }
    }

    public void Chase()
    {
        switch (route[_index - 1])
        {
            case "R":
                {
                    _direction = 2*Vector2.right;
                    _topSpriteRenderer.sprite = _sprites[8];
                    _bottomSpriteRenderer.sprite = _sprites[12];
                    break;
                }
            case "L":
                {
                    _direction = 2*Vector2.left;
                    _topSpriteRenderer.sprite = _sprites[9];
                    _bottomSpriteRenderer.sprite = _sprites[13];
                    break;
                }
            case "D":
                {
                    _direction = new Vector2(-0.25f, -2f);
                    _topSpriteRenderer.sprite = _sprites[10];
                    _bottomSpriteRenderer.sprite = _sprites[14];
                    break;
                }
            case "U":
                {
                    _direction = new Vector2(0.25f, 2f);
                    _topSpriteRenderer.sprite = _sprites[11];
                    _bottomSpriteRenderer.sprite = _sprites[15];
                    break;
                }
        }
    }

    public override void Turn(string direction)
    {
        base.Turn(direction);
        _visibilityController.SetCollider(direction);
    }

    public void Attack()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Damaged();
        IsPlayerFound = false;
    }

    public void Pollute()
    {
        switch (route[_index - 1])
        {
            case "R":
                {
                    _topSpriteRenderer.sprite = _sprites[16];
                    _bottomSpriteRenderer.sprite = _sprites[20];
                    break;
                }
            case "L":
                {
                    _direction = 2 * Vector2.left;
                    _topSpriteRenderer.sprite = _sprites[17];
                    _bottomSpriteRenderer.sprite = _sprites[21];
                    break;
                }
            case "D":
                {
                    _direction = new Vector2(-0.25f, -2f);
                    _topSpriteRenderer.sprite = _sprites[18];
                    _bottomSpriteRenderer.sprite = _sprites[22];
                    break;
                }
            case "U":
                {
                    _direction = new Vector2(0.25f, 2f);
                    _topSpriteRenderer.sprite = _sprites[19];
                    _bottomSpriteRenderer.sprite = _sprites[23];
                    break;
                }
        }
        StartCoroutine(DyingCoroutine());
    }

    IEnumerator DyingCoroutine()
    {
        yield return new WaitForSeconds(3f);
       Destroy(gameObject);
    }

}
