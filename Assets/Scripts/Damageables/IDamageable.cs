namespace Damageables
{
    public interface IDamageable
    {
        DamageableType Type { get; }
        void TakeDamage(float damage);
    }
}