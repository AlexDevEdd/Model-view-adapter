using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Practice
{
    public class EffectView: MonoBehaviour
    {
        [SerializeField] private EffectType _effectType;
        [SerializeField] private Image _icon;
        [SerializeField] private Image _background; 
        [SerializeField] private TextMeshProUGUI _valueText;

        public EffectType EffectType => _effectType;

        public void SetIcon(Sprite icon) => _icon.sprite = icon;

        public void SetBackColor(Color backColor) => _background.color = backColor;

        public void SetValue(string value) => _valueText.text = value;
    }
    
    
}