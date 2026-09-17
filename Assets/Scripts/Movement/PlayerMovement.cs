using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    private IMC_Player playerControls;

    public Image StaminaBar;

    public float moveSpeed = 1f;
    public float stamina = 5f;
    public float maxStamina = 5f;

    private void Awake()
    {
        playerControls = new IMC_Player();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // not needed
       // Vector2 move = playerControls.Player.MoveUpDown.ReadValue<Vector2>();
    }


    // Update is called once per frame
    void Update()
    {

       // Vector2 move = playerControls.Player.MoveUpDown.ReadValue<Vector2>();

       // Debug.Log(move);

        if (playerControls.Player.MoveUpDown.ReadValue<Vector2>() == Vector2.up)
        {
            Debug.Log("W is presssed");
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
        if (playerControls.Player.MoveUpDown.ReadValue<Vector2>() == Vector2.down)
        {
            Debug.Log("S is presssed");
            transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
        }
        if (playerControls.Player.MoveUpDown.ReadValue<Vector2>() == Vector2.right)
        {
            Debug.Log("D is presssed");
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        if (playerControls.Player.MoveUpDown.ReadValue<Vector2>() == Vector2.left)
        {
            Debug.Log("D is presssed");
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }
        if (playerControls.Player.Sprint.ReadValue<float>() > 0)
        {
            Debug.Log("Shift is speed is: " + moveSpeed.ToString());
            moveSpeed = 2f;
            if (stamina > 0f)
            {
                stamina = stamina - 0.001f;
                Debug.Log("Stamia: " + stamina.ToString());
                StaminaBar.fillAmount = stamina / maxStamina;
            }
            else
            {
                moveSpeed = 1f;
            }
        }
        else
        {
            moveSpeed = 1f;
            if (stamina < maxStamina )
            {
                stamina = stamina + 0.001f;
                Debug.Log("Stamia: " + stamina.ToString());
                StaminaBar.fillAmount = stamina / maxStamina;
            }
        }





    }
}
