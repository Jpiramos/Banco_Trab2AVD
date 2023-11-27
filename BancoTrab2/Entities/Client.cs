namespace Course.Entities
{
    public abstract class Client
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public List<Contract> Contracts { get; set; }



        public Client(string name, int age)
        {
            Name = name;
            Age = age;
            Contracts = new List<Contract>();
        }


    }
}
