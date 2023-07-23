using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public Animator anim;
    public PlayerMovement player;
    public TMP_Text HealthText;

    // Damage Trap Indicator
    public int trapDamage;
    public int LavaDamage;

    public bool isPlayerOnTop;

    // Start is called before the first frame update
    void Start()
    {
        anim. GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerOnTop = true;
        if (collision.gameObject.CompareTag("Player"))
        {
            LavaDamage -= player.healthPoints;
            anim.SetBool("isActive", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerOnTop = false;
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isActive", false);
        }
    }

    public void PlayerDamage()
    {
        if (isPlayerOnTop)
        {
            player.healthPoints -= trapDamage;
        }

        HealthText.text = "HP:" + player.healthPoints;
    }
}
