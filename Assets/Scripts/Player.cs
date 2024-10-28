using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float damageReceived;
    public float bulletSpeed;
    public float vulnerabilityRadius;
    public int bulletCooldown;

    public GameObject playerBullet;
    public GameObject ScoreText;
    public Transform bulletSpawn;
    public AudioClip destroyAudio;
    public AudioClip shootAudio;

    private bool gameOver;
    private bool bulletReady = true;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        gameOver = false;
        bulletReady = true;
        score = 0;
        ScoreText.GetComponent<Text>().text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (!gameOver)
        {
            // Debug.Log("Health: " + currentHealth);
        }

        if (currentHealth == 0 || currentHealth < 0)
        {
            currentHealth = 0;

            if (!gameOver)
            {
                GameOver();
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (bulletReady)
            {
                Debug.Log("Pew!");
                GetComponent<AudioSource>().PlayOneShot(shootAudio);
                GameObject bulletInstance;
                bulletInstance = Instantiate(playerBullet, bulletSpawn.position, bulletSpawn.rotation);
                bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * bulletSpeed, ForceMode.Impulse);
                bulletReady = false;
                StartCoroutine(BulletCooldown());
            }
        }
    }

    public void ReceiveDamage()
    {
        currentHealth -= damageReceived;
        Debug.Log("Took " + damageReceived + " Damage! Health is now " + currentHealth + "!");
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        gameOver = true;
        Application.Quit();
    }

    IEnumerator BulletCooldown()
    {
        yield return new WaitForSeconds(bulletCooldown);
        bulletReady = true;
    }

    public void PlayAudio(AudioClip audio)
    {
        GetComponent<AudioSource>().PlayOneShot(audio);
    }

    public void IncrementScore()
    {
        score++;
        ScoreText.GetComponent<Text>().text = score.ToString();
    }
}
