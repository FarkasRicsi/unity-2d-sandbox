using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class SelectObject : MonoBehaviour
{
    private List<CircleBehaviourWithSelected> selectedObjects;

    private void Awake()
    {
        selectedObjects = new List<CircleBehaviourWithSelected>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Hello");
            foreach (CircleBehaviourWithSelected selectableObject in selectedObjects)
            {
                selectableObject.SetSelectedVisible(false);
            }
            selectedObjects.Clear();

            Collider2D[] collider2DArray = Physics2D.OverlapPointAll(UtilsClass.GetMouseWorldPosition());
            foreach (Collider2D collider2D in collider2DArray)
            {
                Debug.Log("Foreach");
                CircleBehaviourWithSelected selectableObject = collider2D.GetComponent<CircleBehaviourWithSelected>();
                if (selectableObject != null)
                {
                    selectedObjects.Add(selectableObject);
                    Debug.Log("Collided objec = " + collider2D.name);
                    selectableObject.SetSelectedVisible(true);
                }
                else
                {
                    Debug.Log("selectableObjects is null");
                }
            }
        }
    }
}
