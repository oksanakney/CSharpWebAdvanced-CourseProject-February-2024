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
            public const int TitleMaxLength = 100;

            public const int ReadingTimeMinValue = 0;
            public const int ReadingTimeMaxValue = 10;

            public const int ContentMinLength = 150;
            public const int ContentMaxLength = 2000;

            public const int ImageUrlMaxLength = 2048;

            public const string DateFormat = "dd/MM/yyyy HH:mm";
        }

        public static class Author
        {
            public const string PhoneNumberRegEx = "^\\+\\d{12}$";
        }
    }
}
