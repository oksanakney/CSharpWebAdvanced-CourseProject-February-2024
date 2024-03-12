namespace NebulaNewsSystem.Common
{
    public static class EntityValidationConstants
    {
        public static class Category
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 30;
        }

        public static class Article 
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 40;

            public const int ContentMinLength = 150;
            public const int ContentMaxLength = 2000;

            public const int ImageUrlMaxLength = 2048;
        }
    }
}
