using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    private CharacterController _controller;
    private UIManager uiManager;
    private int numberOfCoins;

    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 0.5f;
    [SerializeField]
    private float _jumpSpeed = 20.0f;
    private bool _canDoubleJump = false;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(uiManager == null)
        {
            Debug.LogError("Could not find UIManager");
        }
        numberOfCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        float moveSpeed = _speed;
        Vector3 velocity = moveSpeed * direction;
        if(_controller.isGrounded)
        {
            _canDoubleJump = false;
        }
        if (_controller.isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)))
        {
            velocity.y = _jumpSpeed;
            _canDoubleJump = true;
        }
        else if (!_controller.isGrounded)
        {
            bool usedDoubleJump = false;
            if ((_canDoubleJump == true || _controller.velocity.y <= -1) && (Input.GetKeyDown(KeyCode.Space)))
            {
                velocity.y = _jumpSpeed;
                _canDoubleJump = false;
                usedDoubleJump = true;
            }
            if(!usedDoubleJump)
            {
                velocity.y = _controller.velocity.y - _gravity;
            }
            
        }
        _controller.Move(velocity * Time.deltaTime);
    }

    public void CollectedItem()
    {
        numberOfCoins++;
        uiManager.SetCoin(numberOfCoins);
    }
}
