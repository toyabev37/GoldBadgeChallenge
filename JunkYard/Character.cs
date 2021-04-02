namespace JunkYard
{
    public  class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Character()
        {
                
        }

        public Character(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}