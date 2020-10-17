// Importing Namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Declaring variables
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI remainingText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private int remaining;
    private int total;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        remaining = total = GameObject.FindGameObjectsWithTag("PickUp").Length;

        SetText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue) 
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetText()
    {
        countText.text = "Count: " + count.ToString();
        remainingText.text = "Remaining: " + remaining.ToString();
        if(count >= total)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate() 
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            count++;
            remaining--;
            SetText();
        }
    }
}
