using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private PlayerStateMachine _stateMachine;

    public bool IsCanThrowingBomb { get; private set; }
    public bool IsThrownBomb { get; private set; }

    public GameObject currentBomb;

    public GameObject _bombPrefab;

    protected override void Awaken()
    {
        base.Awaken();
        _stateMachine = GetComponent<PlayerStateMachine>();
    }

    protected override void Start()
    {
        IsCanThrowingBomb = true;
        base.Start();
    }


    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);;
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
    }


    public void ThrowBomb()
    {
        IsCanThrowingBomb = false;
        currentBomb = Instantiate(_bombPrefab, transform.position, transform.rotation);
        IsCanThrowingBomb = true;
        IsThrownBomb = false;
    }

    public void TryThrowBomb()
    {
        if (IsCanThrowingBomb)
            IsThrownBomb = true;
    }


}
