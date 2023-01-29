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
    [SerializeField] private float rotSpeed = 1f;

    void Update()
    {
        ReadMoveInput(Time.deltaTime);
        ReadActionInput(Time.deltaTime);
    }

    private void ReadMoveInput(float deltaTime)
    {
        Vector3 movement = Vector3.zero;
        Vector3 rotation = Vector3.zero;

        if (Input.GetKey(UpArrow))
        {
            movement += Vector3.forward;
            rotation = Vector3.zero;
        }
        if (Input.GetKey(DownArrow))
        {
            movement -= Vector3.forward;
            rotation = Vector3.up * 180;
        }

        if (Input.GetKey(RightArrow))
        {
            movement += Vector3.right;
            rotation = Vector3.up * 90;
        }
        if (Input.GetKey(LeftArrow))
        {
            movement -= Vector3.right;
            rotation = Vector3.up * -90;
        }

        if (movement != Vector3.zero)
        {
            transform.Translate(movement * speed * deltaTime, Space.World);
            transform.eulerAngles = rotation;
        }
    }

    private void ReadActionInput(float deltaTime)
    {
        if (Input.GetKey(TaskButton))
        {
            taskManager.TryToExecuteTask(deltaTime);
        }
        else if (Input.GetKeyDown(GrabButton))
        {
            taskManager.TryToToggleSelection();
        }
    }
}
