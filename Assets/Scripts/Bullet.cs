using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDespawnTime;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BulletDespawnTimer());
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<MoveTowardsPlayer>().SpawnAtRandLocation();
            collision.gameObject.GetComponent<MoveTowardsPlayer>().IncreaseSpeed();
            Debug.Log("Destroyed Enemy");
            player.PlayAudio(player.destroyAudio);
            player.IncrementScore();
        }

        Destroy(this.gameObject);
    }

    IEnumerator BulletDespawnTimer()
    {
        yield return new WaitForSeconds(bulletDespawnTime);
        Destroy(this.gameObject);
    }
}
