using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    public string startScene = "Menu";
    [SerializeField]
    public GameObject rules;
    [SerializeField]
    public GameObject menu;
    [SerializeField]
    public GameObject highscore;

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
        #if UNITY_STANDALONE
            //Quit the application
            Application.Quit();
        #endif
 
        #if UNITY_EDITOR
            //Stop playing the scene
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void showRules()
    {
        menu.SetActive(false);
        rules.SetActive(true);
    }

    public void showMenu()
    {
        highscore.GetComponent<TMP_Text>().text = "Highscore: " + PlayerPrefs.GetInt("HighScore").ToString();
        rules.SetActive(false);
        menu.SetActive(true);
    }

    public void hideMenuAndRules()
    {
        menu.SetActive(false);
        rules.SetActive(false);
    }
}
