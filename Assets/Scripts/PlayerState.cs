using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    public int health = 9;
    public int lives = 3;
    public int damage = 6;

    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;

    private SpriteRenderer spriteRenderer;
    private Animator anim;
    public bool isImmune = false;
    private float immunityTime = 0f;
    private float immunityDuration = 1.5f;
    public Text LivesUI;
    //public int CoinCollection;
    public Slider healthUI;
    public Gradient gradient;
  


    // Use this for initialization
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        //fill.color = gradient.Evaluate(1f);
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        healthUI.value = health;
        //fill.color = gradient.Evaluate(healthUI.normalizedValue);

        if (this.isImmune == true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }

        }
        LivesUI.text = "" + lives;

    }
    void SpriteFlicker()
    {
        if (this.flickerTime < this.flickerDuration)
        {
            this.flickerTime = this.flickerTime + Time.deltaTime;
        }
        else if (this.flickerTime >= this.flickerDuration)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;
        }
    }

    public void TakeDamage1(int damage)
    {
        if (this.isImmune == false)
        {
            this.health = this.health - damage;
            if (this.health < 0)
                this.health = 0;
            if (this.lives > 0 && this.health == 0)
            {
                //FindObjectOfType<levelManager>().RespawnPlayer();
                this.health = 9;
                this.lives--;
            }
            else if (this.lives == 0 && this.health == 0)
            {
                anim.Play("Base Layer.Dead", 0, 0.2f);
                Debug.Log("GameOver");
                Destroy(this.gameObject,1.7f);
            }
            Debug.Log("Player Health: " + this.health.ToString());
            Debug.Log("Player Lives: " + this.lives.ToString());
        }
        PlayHitReaction();

    }
    public void LivesRem(int live)
    {
        this.lives = this.lives + live;
    }
    void PlayHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Enemy")
    //    {
    //        FindObjectOfType<PlayerState>().TakeDamage(damage);
    //    }
    //}
}
