using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityController : MonoBehaviour
{
    public bool IsPlayerDetected;

    private BoxCollider2D _thisCollider;
    [SerializeField] Vector2[] _thisColliderSizes, _thisColliderOffsets;

    private void Start()
    {
        _thisCollider = GetComponent<BoxCollider2D>();
        IsPlayerDetected = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            IsPlayerDetected = true;
    }

    //protected override void OnTriggerStay2D(Collider2D collision)
    //{
    //    base.OnTriggerStay2D(collision);
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            IsPlayerDetected = false;
    }

    public void SetCollider(string direction)
    {
        switch (direction)
        {
            case "R":
                {
                    _thisCollider.size = _thisColliderSizes[0];
                    _thisCollider.offset = _thisColliderOffsets[0];
                    break;
                }
            case "L":
                {
                    _thisCollider.size = _thisColliderSizes[1];
                    _thisCollider.offset = _thisColliderOffsets[1];
                    break;
                }
            case "D":
                {
                    _thisCollider.size = _thisColliderSizes[2];
                    _thisCollider.offset = _thisColliderOffsets[2];
                    break;
                }
            case "U":
                {
                    _thisCollider.size = _thisColliderSizes[3];
                    _thisCollider.offset = _thisColliderOffsets[3];
                    break;
                }
        }
    }
}
