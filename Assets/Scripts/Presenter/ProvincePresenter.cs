using UnityEngine;

public class ProvincePresenter : MonoBehaviour
{
    [SerializeField] private ProvinceEventChannelSO provinceSelectedEvent;
    [SerializeField] private ProvinceView view;

    private void OnEnable()
    {
        provinceSelectedEvent.Register(OnProvinceSelectedListener);
    }

    private void OnDisable()
    {
        provinceSelectedEvent.Unregister(OnProvinceSelectedListener);
    }

    private void OnProvinceSelectedListener(Province province)
    {
        view.ProvinceSelected(province);
    }
}
