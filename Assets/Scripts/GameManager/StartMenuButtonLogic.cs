using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartMenuButtonLogic : MonoBehaviour
{
    public Sprite[] backgrounds;
    [SerializeField]
    Image image;
    [SerializeField]
    public static int currentSprite = 0;
    [SerializeField]

    private GameObject startButton;
    [SerializeField]

    private GameObject NextButton;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(ChangePhoto());
    }

    IEnumerator ChangePhoto()
    {
        yield return new WaitForSeconds(10);
        currentSprite++;
        image.sprite = backgrounds[currentSprite];
       StartCoroutine(SecondImage());

    }

    IEnumerator SecondImage()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(1);
    }
    public void ChangeBackGround()
    {
        if (currentSprite == 0)
        {
            currentSprite++;
            image.sprite = backgrounds[currentSprite];
           
        }
        else if(currentSprite == 1)
        {
            currentSprite++;
            image.sprite = backgrounds[currentSprite];
        }
        else if (currentSprite == 2)
        {
            currentSprite++;
            image.sprite = backgrounds[currentSprite];
            startButton.SetActive(true);
            NextButton.SetActive(false);

        }
    }

}
