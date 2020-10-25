﻿using System;
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

            Random rng = new Random(1234);


            Population = GetPopulation(@"C:\Temp\nép.csv");
            BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");

            for (int year = 2005; year <= 2024; year++)
            {
               
                for (int i = 0; i < Population.Count; i++)
                {

                }

                int nbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();
                Console.WriteLine(
                    string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, nbrOfMales, nbrOfFemales));




            }
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

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
    private void SimStep(int year, Person person)
    {
        if (!person.IsAlive) return;
        byte age = (byte)(year - person.BirthYear);

        double pDeath = (from x in Death
                         where x.Gender == person.Gender && x.Age == age
                         select x.P).FirstOrDefault();
        if (rng.NextDouble() <= pDeath)
            person.IsAlive = false;

        if (person.IsAlive && person.Gender == Gender.Female)
        {
            double pBirth = (from x in Birth
                             where x.Age == age
                             select x.P).FirstOrDefault();
            if (rng.NextDouble() <= pBirth)
            {
                Person újszülött = new Person();
                újszülött.BirthYear = year;
                újszülött.NbrOfChildren = 0;
                újszülött.Gender = (Gender)(rng.Next(1, 3));
                Population.Add(újszülött);
            }
        }
    }

}
