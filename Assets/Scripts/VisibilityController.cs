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
                    transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
                    transform.localPosition = Vector3.zero;
                    break;
                }
            case "L":
                {
                    _thisCollider.size = _thisColliderSizes[1];
                    _thisCollider.offset = _thisColliderOffsets[1];
                    transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
                    transform.localPosition = Vector3.zero;
                    break;
                }
            case "D":
                {
                    _thisCollider.size = _thisColliderSizes[2];
                    _thisCollider.offset = _thisColliderOffsets[2];
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 80f), Time.deltaTime*100);
                    //transform.localPosition = new Vector3(1.16f, -6.2f, 0f);
                    break;
                }
            case "U":
                {
                    _thisCollider.size = _thisColliderSizes[3];
                    _thisCollider.offset = _thisColliderOffsets[3];
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 80f), Time.deltaTime*100);
                    //transform.localPosition = new Vector3(1.16f, -6.2f, 0f);
                    break;
                }
        }
    }
}
