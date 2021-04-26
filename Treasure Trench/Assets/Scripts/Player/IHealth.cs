
public interface IHealth
{
	int health { get; }
	void DealDamage(int damage);

	void Heal();
}
