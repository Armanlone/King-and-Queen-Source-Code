using UnityEngine;
using Game.UIManagement;

///<summary>
/// Triggers a zone then fades/unfades tutorial UI.
///</summary>

public class TriggerTutorial : MonoBehaviour
{
    
    public CanvasGroup cnvgTutorial = null;

    public float duration = 1f;

    public string tagGameObject = string.Empty;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (string.IsNullOrEmpty(tagGameObject))
            return;

        if (collision.CompareTag(tagGameObject))
        {
            UIManager.Fade(cnvgTutorial, 1, duration);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (string.IsNullOrEmpty(tagGameObject))
            return;

        if (collision.CompareTag(tagGameObject))
        {
            UIManager.Fade(cnvgTutorial, 0, duration);
        }

    }

}
