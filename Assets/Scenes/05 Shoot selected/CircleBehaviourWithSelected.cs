using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBehaviourWithSelected : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector2 startPos;
    private Vector2 endPos;

    private GameObject selectedGameObject;

    private void Awake()
    {
        selectedGameObject = transform.Find("Selected").gameObject;
        SetSelectedVisible(false);
    }

    void Update()
    {
        Debug.Log(this.GetComponent<Rigidbody2D>().velocity.magnitude);


        if (Input.GetMouseButtonDown(0) == true)
        {
            startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0) == true)
        {
            endPos = Input.mousePosition;
            if (selectedGameObject.activeSelf)
            {
                Shoot(startPos, endPos);
            }            
        }
    }

    private void Shoot(Vector2 startPos, Vector2 endPos)
    {
        float distance = Vector2.Distance(startPos, endPos);
        //Debug.Log("Distance: " + distance);
        if (distance > 100f)
        {
            distance = 100;
            //Debug.Log("Distance: set to 100!");
        }
        Vector2 direction = startPos - endPos;
        Debug.Log("Direction = " + direction);
        this.GetComponent<Rigidbody2D>().AddForce(direction * speed);

    }

    public void SetSelectedVisible(bool visible)
    {
        selectedGameObject.SetActive(visible);
    }
}
