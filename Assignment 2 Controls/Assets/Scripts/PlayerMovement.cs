using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text loseText;
    public GameObject completeLevelUI;

    private Rigidbody rb;
    private int count;
    private AudioSource asr;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        asr = GetComponent<AudioSource>();
        count = 0;
        SetCountText();
        winText.text = "";
        loseText.text = "";
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))

        {
            other.gameObject.SetActive(false);
            asr.Play();
            count = count - 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("End"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("LEVEL WON!");
            CompleteLevel();
        }
    }


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 11)
        {
            winText.text = "You Win!";
        }
        else if(count<0)
        {
            loseText.text = "You Lose!";
        }
    }
}