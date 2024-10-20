using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    // EASY SCENES

    public void Easy1()
    {
        Debug.Log("Scene changed to : SampleScene");
        SceneManager.LoadScene("SampleScene");
    }

    public void Easy2()
    {
        Debug.Log("Scene changed to : Easy2");
        SceneManager.LoadScene("Easy2");
    }

    public void Easy3()
    {
        Debug.Log("Scene changed to : Easy3");
        SceneManager.LoadScene("Easy3");
    }

    // MEDIUM SCENES

    public void Medium1()
    {
        Debug.Log("Scene changed to : Medium");
        SceneManager.LoadScene("Medium");
    }

    public void Medium2()
    {
        Debug.Log("Scene changed to : Medium2");
        SceneManager.LoadScene("Medium2");
    }

    public void Medium3()
    {
        Debug.Log("Scene changed to : Medium3");
        SceneManager.LoadScene("Medium3");
    }

    // HARD SCENES

    public void Hard1()
    {
        Debug.Log("Scene changed to : Hard");
        SceneManager.LoadScene("Hard");
    }

    public void Hard2()
    {
        Debug.Log("Scene changed to : Hard 2");
        SceneManager.LoadScene("Hard 2");
    }

    public void Hard3()
    {
        Debug.Log("Scene changed to : Hard 3");
        SceneManager.LoadScene("Hard 3");
    }
}
