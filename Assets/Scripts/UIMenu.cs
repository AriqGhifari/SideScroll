using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.CheckSaveFile();
        levelCurrent = GameManager.Instance.levelCurrent;
        AddChangeSceneListeners();
        DisableLockedLevel();
        CheckStartPanelExp();
    }

    #region Level Interface Management
    [Header("Level Selection Buttons")]
    public int levelCurrent;
    public Button[] levelButtons;

    public int sceneIndex=0;
    private void AddChangeSceneListeners()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int sceneIndex = i + 1; 
            levelButtons[i].onClick.AddListener(() => GameManager.Instance.ChangeScene(sceneIndex));
        }
    }
    private void DisableLockedLevel()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {   
            if (i > levelCurrent)
            {
                levelButtons[i].interactable = false;
            }   
        }
    }
    #endregion



    #region Panel Management
    //Region ini mengatur agar start panel tidak muncul 2x
    [Header("PanelStart")]
    public GameObject PanelStart ;
    [Header("PanelLv")]
    public GameObject PanelLv;
    public void ShowStartPanel()
    {
        PanelStart.SetActive(true);
        PanelLv.SetActive(false);
    }
    public void ShowLevelPanel() //panggil dibutton Start
    {
        PanelStart.SetActive(false);
        PanelLv.SetActive(true);
        GameManager.Instance.isStart = true;
    }
    
    private void CheckStartPanelExp()
    {
        if (isStart())
        {
            ShowLevelPanel();
            
        }
        else
        {
            ShowStartPanel();
        }
    }

    private bool isStart()
    {
        return GameManager.Instance.isStart;
    }
    #endregion

}