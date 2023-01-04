using UnityEngine;

public class SwordController : MonoBehaviour
{
    private GameObject _sword;
    private Dray _dray;
    
    void Start()
    {
        _sword = transform.Find("Sword").gameObject;
        _dray = transform.parent.GetComponent<Dray>();
        _sword.SetActive(false);
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90 * _dray.facing);
        _sword.SetActive(_dray.mode == Dray.eMode.attack);
    }
}
