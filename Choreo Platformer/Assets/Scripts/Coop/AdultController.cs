using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultController : MonoBehaviour
{
    [SerializeField] private KeyCode UpArrow;
    [SerializeField] private KeyCode DownArrow;
    [SerializeField] private KeyCode LeftArrow;
    [SerializeField] private KeyCode RightArrow;
    [SerializeField] private KeyCode GrabButton;
    [SerializeField] private KeyCode TaskButton;
    [SerializeField] private KeyCode RotateLeft;
    [SerializeField] private KeyCode RotateRight;
    [SerializeField] private AdultTaskManager taskManager;

    [SerializeField] private float speed = 1f;
    [SerializeField] private float rotSpeed = 1f;

    void Update()
    {
        ReadMoveInput(Time.deltaTime);
        ReadActionInput(Time.deltaTime);
    }

    private void ReadMoveInput(float deltaTime)
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(UpArrow))
        {
            movement += Vector3.forward;
        }
        if (Input.GetKey(DownArrow))
        {
            movement -= Vector3.forward;
        }

        if (Input.GetKey(RightArrow))
        {
            movement += Vector3.right;
        }
        if (Input.GetKey(LeftArrow))
        {
            movement -= Vector3.right;
        }

        if (movement != Vector3.zero)
        {
            transform.Translate(movement * speed * deltaTime, Space.World);
        }

        Vector3 rotation = Vector3.zero;
        if (Input.GetKey(RotateLeft))
        {
            rotation -= Vector3.up;
        }
        if (Input.GetKey(RotateRight))
        {
            rotation += Vector3.up;
        }
        if (rotation != Vector3.zero)
        {
            transform.Rotate(rotation * rotSpeed * deltaTime);
        }
    }

    private void ReadActionInput(float deltaTime)
    {
        if (Input.GetKey(TaskButton))
        {
            // Perform task
        }
        else if (Input.GetKeyDown(GrabButton))
        {
            taskManager.TryToToggleSelection();
        }
    }
}
