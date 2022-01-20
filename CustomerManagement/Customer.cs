namespace CustomerManagement
{
    public struct Customer
    {

        public string Name => name;
        private string name;

        public Customer(string name)
        {
            this.name = name;
        }
    }
}