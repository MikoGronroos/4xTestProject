using TMPro;
using UnityEngine;

public class ProvinceView : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI provinceNameText;
    [SerializeField] private TextMeshProUGUI provincePopulationText;
    [SerializeField] private GameObject provincePanelGameObject;

    public void ProvinceSelected(string name, ProvinceData province)
    {
        provincePanelGameObject.SetActive(true);
        provinceNameText.text = name;

        #region Assign Data

        if (province == null) return;

        provincePopulationText.text = province.Population.ToString();

        #endregion
    }

}
