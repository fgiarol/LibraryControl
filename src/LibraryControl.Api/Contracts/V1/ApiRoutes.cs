namespace LibraryControl.Api.Contracts.V1
{
    public static class ApiRoutes
    {
        private const string Root = "api";
        private const string Version = "v1";
        private const string Base = Root + "/" + Version;

        public static class Authors
        {
            public const string Get = Base + "/authors/{authorId:guid}";
            public const string GetAll = Base + "/authors";
            public const string Create = Base + "/authors";
            public const string Update = Base + "/authors/{authorId:guid}";
            public const string Delete = Base + "/authors/{authorId:guid}";
        }

        public static class Books
        {
            public const string Get = Base + "/books/{bookId:guid}";
            public const string GetAll = Base + "/books";
            public const string Create = Base + "/books";
            public const string Update = Base + "/books/{bookId:guid}";
            public const string Delete = Base + "/books/{bookId:guid}";
        }

        public static class Genres
        {
            public const string Get = Base + "/genres/{genreId:guid}";
            public const string GetAll = Base + "/genres";
            public const string Create = Base + "/genres";
            public const string Update = Base + "/genres/{genreId:guid}";
            public const string Delete = Base + "/genres/{genreId:guid}";
        }

        public static class Users
        {
            public const string Login = Base + "/users/login";
            public const string Get = Base + "/users/{userId:guid}";
            public const string Create = Base + "/users";
            public const string Update = Base + "/users/{userId:guid}";
            public const string Delete = Base + "/users/{userId:guid}";
        }
    }
}