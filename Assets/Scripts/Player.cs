using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public float jumpForce;
    public Rigidbody rb;
    public int score;
    public Text ScoreText;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            thisAnimation.Play();
        }
        if(transform.position.y>= 3.52)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (transform.position.y <= -3.69)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag ("Obstacle"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag ("PassObstacle"))
        {
            score+=1;
            ScoreText.GetComponent<Text>().text = "Score :" + score;
        }
    }
}
