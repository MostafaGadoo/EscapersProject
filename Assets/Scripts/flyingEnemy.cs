using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingEnemy : enemyController
{
    public float HorizzontalSpeed;
    public float VerticalSpeed;
    public float amplitude;

    private Vector3 temp_position;
    public float moveSpeed;
    private controller player;

    // Start is called before the first frame update
    void Start()
    {
        temp_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        temp_position.x += HorizzontalSpeed;
        temp_position.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * amplitude;
        transform.position = temp_position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            FindObjectOfType<PlayerState>().TakeDamage1(damage);
        }
    }
}
