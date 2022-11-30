using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text CountText;
    public Text WinText;
    
    private Rigidbody rb;
    private int count;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        count = 0;
        WinText.text = "";
        SetCountText();  
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);  
            count++;
            SetCountText();
        }
    }
    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();  
        if (count >= 12)
        {
            WinText.text = "You Win!";
        }
    }
}
