using UnityEngine;
using UnityEngine.UI;

public class ExitButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button exitButton = GetComponent<Button>();
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);
        }
    }

    void ExitGame()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }
}
