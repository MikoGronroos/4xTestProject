using TMPro;
using UnityEngine;

public class ProvinceView : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI provinceNameText;

    public void ProvinceSelected(Province province)
    {
        provinceNameText.text = province.name;
    }

}
