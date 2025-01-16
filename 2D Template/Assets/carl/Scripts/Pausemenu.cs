using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    public KeyCode pause;
    public GameObject pausemenu;
    // Start is called before the first frame update
    void Start()
    {
        pausemenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pause))
        {
            Time.timeScale = 0;
            pausemenu.SetActive(true);
            GetComponent<SummonItem>().canUseItem = false;
        }
    }

    public void Play()
    {
        Time.timeScale = 1;
        pausemenu.SetActive(false);
        GetComponent<SummonItem>().canUseItem = true;
    }

    public void SecretButton()
    {
        Time.timeScale = 10;
        pausemenu.SetActive(false);
    }
    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
