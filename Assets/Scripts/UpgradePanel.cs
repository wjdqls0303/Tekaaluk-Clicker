using UnityEngine.UI;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField]
    private Image abilityImage = null;
    [SerializeField]
    private Text abilityNameText = null;
    [SerializeField]
    private Text priceText = null;
    [SerializeField]
    private Text amountText = null;
    [SerializeField]
    private Button purchaseButton = null;
    [SerializeField]
    private Sprite[] abilitySprite;

    private Ability ability = null;

    private User user = null;

    public void Start()
    {
        UpdateUpgradePanelUI();
    }

    public void SetValue(Ability ability)
    {
        this.ability = ability;
        UpdateUpgradePanelUI();
    }

    public void UpdateUpgradePanelUI()
    {
        abilityImage.sprite = abilitySprite[ability.abilityNumber];
        abilityNameText.text = ability.abilityName;
        priceText.text = string.Format("{0} ¸¶¸®", ability.Price);
        amountText.text = string.Format("{0} °³", ability.Amount);
    }

    public void OnClickPurchase()
    {
        if(GameManager.Instance.CurrentUser.fish < ability.Price)
        {
            return;
        }
        GameManager.Instance.CurrentUser.fish -= ability.Price;
        ability.Amount++;
        ability.Price = (long)(ability.Price * 2.5f);
        if(ability.abilityNumber == 0)
        {
            GameManager.Instance.CurrentUser.fpc *= 3;
            ability.Price *= 6;
        }
        UpdateUpgradePanelUI();
        GameManager.Instance.UI.UpdateFishPanel();
    }
}
