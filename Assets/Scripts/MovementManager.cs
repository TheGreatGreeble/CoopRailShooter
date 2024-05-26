using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField] public GameObject Player1;
    [SerializeField] public GameObject Player2;
    [SerializeField] float speed = 10f;
    [SerializeField] float acceleration = 2f;
    private CharacterController characterControllerP1;
    private CharacterController characterControllerP2;
    private Vector3 currentVelocityP1 = Vector3.zero;
    private Vector3 currentVelocityP2 = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        characterControllerP1 = Player1.GetComponent<CharacterController>();
        characterControllerP2 = Player2.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player 1 move calculation
        Vector3 inputDirectionP1 = Player1.transform.right * Input.GetAxis("Horizontal");

        // Accelerate Player 1 towards desired velocity
        currentVelocityP1 = transform.TransformVector(Vector3.MoveTowards(currentVelocityP1, inputDirectionP1, acceleration * Time.deltaTime));

        // Player 2 move calculation
        Vector3 inputDirectionP2 = Player2.transform.right * Input.GetAxis("Vertical");

        // Accelerate Player 2 towards desired velocity
        currentVelocityP2 = transform.TransformVector(Vector3.MoveTowards(currentVelocityP2, inputDirectionP2, acceleration * Time.deltaTime));

        // Move the players
        characterControllerP1.Move(currentVelocityP1 * speed * Time.deltaTime);
        characterControllerP2.Move(currentVelocityP2 * speed * Time.deltaTime);
    }
}
