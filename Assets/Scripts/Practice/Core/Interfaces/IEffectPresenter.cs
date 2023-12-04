using System;
using Practice.Effects;

namespace Practice.Core.Interfaces
{
    public interface IEffectPresenter : IDisposable
    {
        public EffectView GetEffectView();
        public Effect GetEffect();
        public void IncreaseEffectValue();
        public void Dispose();
    }
}