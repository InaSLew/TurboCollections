namespace CustomerManagement
{
    public struct Customer
    {
        private readonly int id;
        private static int nextId;

        public string FirstName => firstName;
        private string firstName;

        public string LastName => lastName;
        private string lastName;

        public Customer(string firstName, string lastName)
        {
            id = nextId++;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}