using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MessageSystem : MonoBehaviour {

    public GameObject Tooltip;
    public GameObject Warning;
    public GameObject Legend;

    public static MessageSystem instance = new MessageSystem();

    public static MessageSystem getInstance()
    {
        return instance;
    }

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        hideText(Tooltip);
        hideText(Warning);
        hideText(Legend);

        setText("Oi", Tooltip);
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 mousePos = Input.mousePosition;

        Tooltip.transform.position = mousePos + new Vector2(Tooltip.GetComponent<RectTransform>().rect.width / 2 + 15, -Tooltip.GetComponent<RectTransform>().rect.height);
	}

    public static void setText(string text, GameObject target)
    {
        target.GetComponentInChildren<Text>().text = text;
        target.SetActive(true);
    }

    public void hideText(GameObject target)
    {
        target.SetActive(false);
    }
}
