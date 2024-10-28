using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNoise : MonoBehaviour
{
    private float enemyHeight;
    private float pitch;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
        enemyHeight = transform.position.y + 1.5f;
        pitch = enemyHeight / 10 + 1;
        if (pitch > 0 || pitch == 0)
        {
            if (pitch < 3.0f || pitch == 3.0f)
            {
                GetComponentInChildren<AudioSource>().pitch = pitch;
            }

            else
            {
                GetComponentInChildren<AudioSource>().pitch = 3.0f;
            }
        }

        else
        {
            GetComponentInChildren<AudioSource>().pitch = 0;
        }

    }
}
