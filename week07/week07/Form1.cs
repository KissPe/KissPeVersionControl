using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week07.Entities;

namespace week07
{
    public partial class Form1 : Form
    {

        List<Person> Population = new List<Person>();
        List<Birth> BirthProbabilities = new List<Birth>();
        List<Death> DeathProbabilities = new List<Death>();

        public Form1()
        {
            InitializeComponent();




            Population = GetPopulation(@"C:\Temp\nép.csv");
            BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");
        }

        private List<Death> GetDeathProbabilities(string v)
        {
            throw new NotImplementedException();
        }

        private List<Birth> GetBirthProbabilities(string v)
        {
            throw new NotImplementedException();
        }

        private List<Person> GetPopulation(string v)
        {
            throw new NotImplementedException();
        }
    }
    public List<Person> GetPopulation(string csvpath)
    {
        List<Person> population = new List<Person>();

        using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
        {
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine().Split(';');
                population.Add(new Person()
                {
                    BirthYear = int.Parse(line[0]),
                    Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                    NbrOfChildren = int.Parse(line[2])
                });
            }
        }

        return population;
    }
}
