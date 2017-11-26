using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public int buttonsLayer;

    // Use this for initialization
    void Start () {
        buttonsLayer = 1 << buttonsLayer;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject currentObject_MouseOver = getObjectMouseOver();
        if(currentObject_MouseOver != null)
        {
            //Change object on mouse over
            mouseOverObject(currentObject_MouseOver);
        }

        if (Input.GetMouseButtonDown(0))
        {
            //Change object on click
            if (currentObject_MouseOver != null)
            {
                executeCommand(currentObject_MouseOver);
            }
        }

    }

    public GameObject getObjectMouseOver()
    {
        RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.zero, 0, buttonsLayer);
        if (hit.collider != null)
        {
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }

    public virtual void executeCommand(GameObject currObject)
    {
        switch(currObject.name)
        {
            
            default:
                break;
        }
    }

    public virtual void mouseOverObject(GameObject currObject)
    {
        switch (currObject.name)
        {

            default:
                break;
        }
    }
}
