using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followEnemy : enemyController
{
    // Start is called before the first frame update
    private controller player;
    
    void Start()
    {
        player = FindObjectOfType<controller>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, maxSpeed * Time.deltaTime);
    }
}
