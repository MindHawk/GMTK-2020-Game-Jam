using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedLife : MonoBehaviour
{
    public float TimeToLive = 10;

    private float _timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        _timeLeft = TimeToLive;
    }

    // Update is called once per frame
    void Update()
    {
        _timeLeft -= Time.deltaTime;
        if (_timeLeft <= 0)
        {
            Destroy(gameObject);
        }
    }
}
