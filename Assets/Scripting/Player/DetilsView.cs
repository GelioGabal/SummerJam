using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DetilsView : MonoBehaviour
{
    [SerializeField] TMP_Text count;

    private void Start()
    {

        Details.OnDetailsChanged += UpdateView;

        UpdateView(Details.GetDetailsCount());
    }

    private void OnDestroy()
    {
        Details.OnDetailsChanged -= UpdateView;
    }

    private void UpdateView(int newCount)
    {
        if (count != null)
        {
            count.text = string.Format(newCount+"/10");
        }
        else
        {
            Debug.LogError("TMP_Text не назначен в DetailsView!");
        }
    }

    public void RefreshView()
    {
        UpdateView(Details.GetDetailsCount());
    }
}
