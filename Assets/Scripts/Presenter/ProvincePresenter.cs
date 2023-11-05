using UnityEngine;

public class ProvincePresenter : MonoBehaviour
{
    [SerializeField] private ProvinceDataEventChannelSO provinceSelectedEvent;
    [SerializeField] private ProvinceView view;
    [SerializeField] private ProvincePositionsConfig _positions;

    private void OnEnable()
    {
        provinceSelectedEvent.Register(OnProvinceSelectedListener);
    }

    private void OnDisable()
    {
        provinceSelectedEvent.Unregister(OnProvinceSelectedListener);
    }

    private void OnProvinceSelectedListener(string name, ProvinceData provinceData)
    {
        view.ProvinceSelected(name, provinceData);
    }
}
