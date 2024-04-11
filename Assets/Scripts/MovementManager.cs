using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField] public GameObject Player1;
    [SerializeField] public GameObject Player2;
    [SerializeField] float speed;
    private CharacterController characterControllerP1;
    private CharacterController characterControllerP2;
    private float verticalVelocity = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        characterControllerP1 = Player1.GetComponent<CharacterController>();
        characterControllerP2 = Player2.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //player 1 move calculation
        Vector3 moveP1 = Player1.transform.right * Input.GetAxis("Horizontal");
        //player 2 move calculation
        Vector3 moveP2 = Player2.transform.right * Input.GetAxis("Vertical");
        if (!characterControllerP1.isGrounded || !characterControllerP2.isGrounded)
        {
            verticalVelocity -= (10 * Time.deltaTime);
        }

        characterControllerP1.Move((moveP1 + verticalVelocity * Vector3.up) * Time.deltaTime * speed);
        characterControllerP2.Move((moveP2 + verticalVelocity * Vector3.up) * Time.deltaTime * speed);
    }
}
