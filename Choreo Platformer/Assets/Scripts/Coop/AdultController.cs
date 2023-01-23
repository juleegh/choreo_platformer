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
    [SerializeField] private AdultTaskManager taskManager;

    [SerializeField] private float speed = 1f;

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
            transform.Translate(movement * speed * deltaTime);
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
