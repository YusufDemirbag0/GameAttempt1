using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public Renderer ghostRenderer;
    int count;
    private PlayerScript playerScript;

    void Awake()
    {
        playerScript = GameObject.FindObjectOfType<PlayerScript>();
    }

    void Start()
    {
        count = 0;
        float x = Random.Range(-5, 5);
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(x, -2f);
    }
    void Update()
    {
        if (this.gameObject.transform.position.y <= -6.5f)
        {
            Destroy(this.gameObject);    
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ghostRenderer.enabled = false;
        }

        if (Input.GetKeyDown("space"))
        {
            ghostRenderer.enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Laser"))
        {
            count ++;
            playerScript.UpdateScore(count);
            Destroy(this.gameObject);
        }
    }
}

