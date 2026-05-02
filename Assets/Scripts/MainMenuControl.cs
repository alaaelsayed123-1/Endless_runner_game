using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject bounceText;
    [SerializeField] GameObject bigButton;
    [SerializeField] GameObject animCam;
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject menuControls;
    [SerializeField] AudioSource buttonSelect;
    public static bool hasClicked;
    [SerializeField] GameObject staticCam;
    [SerializeField] GameObject fadeIn;

    [SerializeField] GameObject coinDisplay;
    [SerializeField] GameObject gemDisplay;
    [SerializeField] GameObject distanceDisplay;

    void Start()
    {
       

        StartCoroutine(FadeInTurnOff());

        if (hasClicked == true)
        {
            staticCam.SetActive(true);
            animCam.SetActive(false);
            menuControls.SetActive(true);
            bounceText.SetActive(false);
            bigButton.SetActive(false);
        }
    }

    void Update()
    {
        
    }

    public void MenuBeginButton()
    {
        StartCoroutine(AnimCam());
    }

    public void StartGame()
    {
        StartCoroutine(StartButton());
    }

    IEnumerator StartButton()
    {
        buttonSelect.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }

    IEnumerator AnimCam()
    {
        animCam.GetComponent<Animator>().Play("AnimMenuCam");
        bounceText.SetActive(false);
        bigButton.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        fadeIn.SetActive(false);
        mainCam.SetActive(true);
        animCam.SetActive(false);
        menuControls.SetActive(true);
        hasClicked = true;
    }

    IEnumerator FadeInTurnOff()
    {
        yield return new WaitForSeconds(0.05f);
        int loadedCoins = PlayerPrefs.GetInt("COINSAVE");
        int loadedGems = PlayerPrefs.GetInt("GEMSAVE");
        int loadedDistance = PlayerPrefs.GetInt("DISTANCESAVE");

        coinDisplay.GetComponent<TMP_Text>().text = loadedCoins.ToString();
        gemDisplay.GetComponent<TMP_Text>().text = loadedGems.ToString();
        distanceDisplay.GetComponent<TMP_Text>().text = loadedDistance.ToString();
        yield return new WaitForSeconds(1);
        fadeIn.SetActive(false);
    }
}