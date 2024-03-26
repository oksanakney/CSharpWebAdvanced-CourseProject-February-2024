namespace NebulaNewsSystem.Common
{
    public static class EntityValidationConstants
    {
        public static class Article
        {
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 50;

            public const int DescriptionMinLength = 15;
            public const int DescriptionMaxLength = 200;

            public const int ContentMinLength = 50;
            public const int ContentMaxLength = 2000;

            public const int ImageUrlMaxLength = 2048;

            public const string DateFormat = "HH:mm dd/MM/yyyy";
        }

        public static class Author
        {
            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
        }

        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 35;
        }

        public static class Comment 
        {
            public const int ContentMinLength = 1;
            public const int ContentMaxLength = 200;

            public const string DateFormat = "HH:mm dd/MM/yyyy";
        }

        public static class Tag
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }
    }
}
