using Practice.Effects;

namespace Practice.Core.Interfaces
{
    public interface IEffectPresenter
    {
        public Effect Effect { get; }
        public EffectView View { get; }
        public void Dispose();
    }
}