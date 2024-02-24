using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace Module_13_WPF_Delegat_HomeWork.BackEnd
{
    class Client
    {
        public uint Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string SeriesPassportNumber { get; set; }
        public List<Client> ClientsList { get; set; }
        public Client() : this(0, "", "", "", "", "")
        {

        }
        public Client(uint id, string lastName, string name, string surname,
                      string phoneNumber, string seriesPassportNumber)
        {
            this.Id = id;
            this.LastName = lastName;
            this.Name = name;
            this.Surname = surname;
            this.PhoneNumber = phoneNumber;
            this.SeriesPassportNumber = seriesPassportNumber;
        }
        public Client this[int index]
        {
            get { return ClientsList[index]; }
        }
        public override string ToString()
        {
            return $"{Id} {LastName} {Name} {Surname} {PhoneNumber} {SeriesPassportNumber}";
        }
        public string GetPathClient()
        {
            return "C:\\Users\\User\\source\\repos\\Module_13_WPF_Delegat_HomeWork\\DB\\clients.csv";
        }
        public void AddFakeClient(int countClients)
        {
            using (StreamWriter sw = new StreamWriter(GetPathClient()))
            {
                for (int i = 1; i < countClients; i++)
                {
                    var faker = new Faker();
                    Random rand = new Random();

                    sw.WriteLine($"{i}|" +
                                $"{faker.Person.LastName}|" +
                                $"{faker.Person.FirstName}|" +
                                $"{faker.Person.UserName}|" +
                                $"{faker.Phone.PhoneNumber()}|" +
                                $"{rand.Next(100_000_000, 9_000_000_00)}_{rand.Next(10000, 90000)}|");
                }
            }
        }
        public static uint GetCurrentId()
        {   
            Manager manager = new Manager();

            List<Manager> db = manager.GetAllClient();

            HashSet<uint> idHash = new HashSet<uint>();

            uint idCurrent = (uint)db.Count;

            foreach (Manager client in db)
            {
                idHash.Add(client.Id);
            }
            while (true)
            {
                idCurrent++;

                if (!idHash.Contains((uint)idCurrent))
                {
                    return idCurrent;
                }
                continue;
            }
        }
        
    }
}
