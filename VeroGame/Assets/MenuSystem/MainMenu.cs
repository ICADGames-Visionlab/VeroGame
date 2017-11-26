using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MenuController {

    public override void executeCommand(GameObject currObject)
    {
        switch (currObject.name)
        {
            case "start":
                SceneManager.LoadScene(0);
                break;
            default:
                break;
        }
    }

    public override void mouseOverObject(GameObject currObject)
    {
        switch (currObject.name)
        {

            default:
                break;
        }
    }
}
