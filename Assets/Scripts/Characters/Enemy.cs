using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] string[] route;

    private EnemyStateMachine _stateMachine;
    private int _index = 1;

    protected override void Awaken()
    {
        base.Awaken();
        _index = 1;
        Turn(route[_index - 1]);
        _stateMachine = GetComponent<EnemyStateMachine>();
    }

    protected override void Start()
    {
        base.Start();
    }

    public void CheckDestination()
    {
        //Debug.Log(route[_index - 1]);
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

}
