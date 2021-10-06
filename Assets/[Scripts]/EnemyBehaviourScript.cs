using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    [Header("Enemy Movement")]
    public BoundsStruct Ebounds;
    public BoundsStruct StartRange;

    private float startPoint;
    private float randomSpeed;

    // Start is called before the first frame update
    void Start()
    {
        randomSpeed = Random.Range(Ebounds.Min, Ebounds.Max);
        startPoint = Random.Range(StartRange.Min, StartRange.Max);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time, randomSpeed) + startPoint, transform.position.y);
    }
}
