using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Practice
{
    public class EffectView: MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Image _background; 
        [SerializeField] private TextMeshProUGUI _valueText;

        public void SetView(Effect effect)
        {
            _icon.sprite = effect.Icon;
            _valueText.text = effect.Value.ToString();
            _background.color = effect.Color;
        }
        
        public void UpdateValue(string value) 
            => _valueText.text = value;
    }
    
    
}