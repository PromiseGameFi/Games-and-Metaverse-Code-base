using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateUrl : MonoBehaviour
{
    public GameObject url;
    // Start is called before the first frame update
    public void LetsGo()
    {
        //gamingurl is the url to send to the Game
        string gamingurl = PlayerPrefs.GetString(url.GetComponentInChildren<Text>().text);
        PlayerPrefs.SetString("urlinput", gamingurl);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
