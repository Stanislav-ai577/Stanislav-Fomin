using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroCreater : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _money;
    [SerializeField] private TMP_InputField _nameInput;
    [SerializeField] private TMP_InputField _moneyInput;
    [SerializeField] private Button _nameAceptButton;

    private void Awake()
    {
        Sprite foundIcon = Resources.Load<Sprite>("Elf");
        _icon.sprite = foundIcon;
        _nameAceptButton.onClick.AddListener(CreateName);
        _nameAceptButton.onClick.AddListener(CreateHeroMoney);
    }

    private void CreateName()
    {
        _name.text = _nameInput.text;
        _nameInput.text = "";
    }

    private void CreateHeroMoney()
    {
        _money.text = _moneyInput.text;
        _moneyInput.text = "";
    }
}
