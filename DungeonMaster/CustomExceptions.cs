namespace DungeonMaster
{
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException()
        {
        }

        public InvalidArmorException(string message)
            : base(message)
        {
        }

        public InvalidArmorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException()
        {
        }

        public InvalidWeaponException(string message)
            : base(message)
        {
        }

        public InvalidWeaponException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}