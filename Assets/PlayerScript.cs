using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Renderer playerRenderer;
    int score = 0;
    public GameObject GhostPrefab;
    public GameObject LaserPrefab;
    float timeController = 0f;
    float time = 0f;

   public void UpdateScore(int count)
    {
        score += count;
    }

    void Start()
    {
        
    }

    void Update()
    {
        float a = this.gameObject.transform.position.x;

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            gameObject.transform.Translate(new Vector2(0.0f, -10.0f) * Time.deltaTime);
        }

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            gameObject.transform.Translate(new Vector2(0.0f, 10.0f) * Time.deltaTime);
        }

        time += Time.deltaTime;
        timeController += Time.deltaTime;
        float x = Random.Range(-6f, 6f);

        if (timeController > 1.0)
        {
            timeController = 0;
            GameObject g = Instantiate(GhostPrefab, new Vector2(x, 4.0f), Quaternion.identity);
            g.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }

        if (time > 30)
        {
            Debug.Log("YOU WIN! Your Score Is:" + score);
            UnityEditor.EditorApplication.isPlaying = false;
        }

        if (Input.GetKeyDown("space"))
        {
            GameObject l = Instantiate(LaserPrefab, new Vector2(a, -3.6f), Quaternion.identity);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            playerRenderer.enabled = false;
        }

        if (Input.GetKeyDown("space"))
        {
            playerRenderer.enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            Debug.Log("YOU LOSE! Your Score Is:" + score);
            Time.timeScale = 0;
        }
    }
}
