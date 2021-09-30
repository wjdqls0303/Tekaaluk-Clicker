using UnityEngine.SceneManagement;
using UnityEngine;

public class ViewChange : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnClickExplainButton()
    {
        SceneManager.LoadScene("Main");
    }
}
