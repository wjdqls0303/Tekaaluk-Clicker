using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text fishText = null;
    //[SerializeField]
    //private Animator catAnimator = null;
    [SerializeField]
    private GameObject upgradePanelTemplate = null;
    [SerializeField]
    private FishText fishTextTemplate = null;
    [SerializeField]
    private RectTransform controlPanel = null;
    [SerializeField]
    private GameObject menuSet = null;

    [SerializeField]
    private SoundManager soundManager = null;
    private List<UpgradePanel> upgradePanelList = new List<UpgradePanel>();
    void Start()
    {
        soundManager = GetComponent<SoundManager>();
        CreatePanels();
        UpdateFishPanel();
    }

    private void CreatePanels()
    {
        GameObject newPanel = null;
        UpgradePanel newPanelComponent = null;

        foreach(Ability ability in GameManager.Instance.CurrentUser.abilityList)
        {
            newPanel = Instantiate(upgradePanelTemplate, upgradePanelTemplate.transform.parent);
            newPanelComponent = newPanel.GetComponent<UpgradePanel>();
            newPanelComponent.SetValue(ability);
            newPanel.SetActive(true);
        }
    }


    public void OnClickCat()
    {
        GameManager.Instance.CurrentUser.fish += GameManager.Instance.CurrentUser.fpc;
        //catAnimator.Play("Click");

        UpdateFishPanel();
        FishText newText = null;

        if (GameManager.Instance.Pool.childCount > 0)
        {
            newText = GameManager.Instance.Pool.GetChild(0).GetComponent<FishText>();
            newText.transform.SetParent(fishTextTemplate.transform.parent);
        }
        else
        {
            newText = Instantiate(fishTextTemplate, fishTextTemplate.transform.parent);
        }

        newText.Show(Input.mousePosition);
    }
    
    public void OnclickMenuButton()
    {
        menuSet.SetActive(true);
    }

    public void OnclickExitButton()
    {
        Application.Quit();
    }

    public void OnclickcontinueButton()
    {
        menuSet.SetActive(false);
    }

    public void OnToggleChanged(bool isOn)
    {
        controlPanel.DOAnchorPosY(isOn ? 925f : -310f, 0.4f).SetEase(Ease.InCirc);
    }

    public void UpdateFishPanel()
    {
        fishText.text = string.Format("{0} ¸¶¸®", GameManager.Instance.CurrentUser.fish); 
    }
}
