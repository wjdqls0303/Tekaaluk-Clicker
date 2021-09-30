using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;

public class FishText : MonoBehaviour
{
    private Text fishText = null;

    public void Show(Vector2 mousePosition)
    {
        fishText = GetComponent<Text>();
        fishText.text = string.Format("+{0}", GameManager.Instance.CurrentUser.fpc);
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 10f);

        RectTransform rectTransform = GetComponent<RectTransform>();

        float targetPositionY = rectTransform.anchoredPosition.y + 100f;
        gameObject.SetActive(true);

        rectTransform.DOAnchorPosY(targetPositionY, 0.5f);
        fishText.DOFade(0f, 0.5f).OnComplete(() => Despawn());
    }

    private void Despawn()
    {
        fishText.DOFade(1f, 0f);
        transform.SetParent(GameManager.Instance.Pool);
        gameObject.SetActive(false);
    }
}
