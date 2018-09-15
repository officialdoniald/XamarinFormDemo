namespace XamarinFormDemo.Model
{
    /// <summary>
    /// DB: Felhasznalok, the users of our application.
    /// </summary>
    public class User
    {
        /// <summary>
        /// DB: ID, user's ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// DB: Email, user's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// DB: Name, user's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// DB: Age, user's age.
        /// </summary>
        public int Age { get; set; }
    }
}
