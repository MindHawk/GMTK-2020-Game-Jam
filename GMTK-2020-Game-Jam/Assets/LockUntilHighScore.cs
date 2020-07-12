using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockUntilHighScore : MonoBehaviour
{
    public int highScoreRequirement = 0;
    public Image lockedImage;
    public Text lockedText;

    private int _highScore;
    // Start is called before the first frame update
    void Awake()
    {
        CheckIfUnlocked();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reload()
    {
        CheckIfUnlocked();
    }

    private void CheckIfUnlocked()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");
        if (_highScore < highScoreRequirement && PlayerPrefs.GetInt("UnlockAll") == 0)
        {
            GetComponent<Button>().interactable = false;
            lockedText.enabled = true;
            lockedImage.color = new Color(255, 255, 255, 0.5f); // transparency
        }
        else
        {
            GetComponent<Button>().interactable = true;
            lockedText.enabled = false;
            lockedImage.color = new Color(255, 255, 255, 1f);
        }
    }
}
