using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, 7f);

        if (this.gameObject.transform.position.y >= 6f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            Destroy(this.gameObject);
        }
    }
}
