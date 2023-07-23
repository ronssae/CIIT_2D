using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collectibles : MonoBehaviour
{

    public bool speed, health;
    public int speedBoost, healthBoost, duration;
    public int baseMovespeed;
    public PlayerMovement player;
    public TMP_Text HealthText;
    private void Start()
    {
        baseMovespeed = player.moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (speed)
        {
            player.moveSpeed += speedBoost;
            StartCoroutine(BackToBaseSpeed());
        }
        if (health)
        {
            player.healthPoints += healthBoost;

            HealthText.text = "HP:" + player.healthPoints;
        }
    }
    IEnumerator BackToBaseSpeed()
    {
        yield return new WaitForSeconds(duration);
        player.moveSpeed = baseMovespeed;
    }
}

