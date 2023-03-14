public class WeaponDecorator : IWeapon
{
    protected IWeapon weapon;
    
    public WeaponDecorator(IWeapon weapon)
    {
        this.weapon = weapon;
    }
    public string Name { get; set; }
    public int Damage { get => weapon.Damage; set => weapon.Damage = value; }
    public int FitPoint { get => weapon.FitPoint; set => weapon.FitPoint = value; }

    public void Attack()
    {
        if (weapon.FitPoint < 0)
        {
            weapon.Damage -= 3;
        } else if (weapon.FitPoint > 0 && weapon.FitPoint <=2)
        {
            weapon.Damage += 1;
        } else if (weapon.FitPoint > 2)
        {
            weapon.Damage += 3;
        }
        weapon.Attack();
    }
}
