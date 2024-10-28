using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private Player player;
    private Transform playerTrans;
    public float speed;
    public float speedMult;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        playerTrans = player.transform;

        SpawnAtRandLocation();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerTrans.position, step);
        
        if (Vector3.Distance(transform.position, playerTrans.position) < player.GetComponent<Player>().vulnerabilityRadius)
        {
            player.ReceiveDamage();
            this.gameObject.SetActive(false);
        }
    }

    public void SpawnAtRandLocation()
    {
        Vector3 randomPos = Random.onUnitSphere * 20;

        transform.position = new Vector3(randomPos.x, Mathf.Abs(randomPos.y), randomPos.z);

        Debug.Log("Distance from Enemy to Player: " + Vector3.Distance(player.transform.position, transform.position));
    }

    public void IncreaseSpeed()
    {
        speed *= speedMult;
    }
}
