public static class ManaForAlly
{
    private const float FireManaAmount = 25f;
    private const float IceManaAmount = 25f;
    private const float WarriorManaAmount = 25f;
    private const float GnomeManaAmount = 25f;

    public static float GetMana(AttackType type)
    {
        switch (type)
        {
            case AttackType.Fire : return FireManaAmount;
            case AttackType.Ice : return IceManaAmount;
            case AttackType.Warrior : return WarriorManaAmount;
            case AttackType.Gnome : return GnomeManaAmount;
        }

        return 0f;
    }
}