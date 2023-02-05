using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    public string startScene = "Menu";
    [SerializeField]
    public GameObject rules;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void quitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void showRules()
    {
        GameObject.FindGameObjectWithTag("Menu").SetActive(false);
        rules.SetActive(true);
    }

    public void showMenu()
    {
        rules.SetActive(false);
        GameObject.FindGameObjectWithTag("Menu").SetActive(true);
    }

    public void hideMenuAndRules()
    {
        GameObject.FindGameObjectWithTag("Menu").SetActive(false);
        rules.SetActive(false);
    }
}
