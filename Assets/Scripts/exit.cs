using UnityEngine;
using UnityEngine.SceneManagement;
//using static System.Net.Mime.MediaTypeNames;

public class exit : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        { 
            //SceneManager.LoadScene("menu");
            Application.Quit();
        }
    }
}
