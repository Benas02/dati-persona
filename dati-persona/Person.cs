﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dati_persona
{
    public class Person {
        #region "Proprietà"
        // -------------------- Proprietà --------------------
        public string firstName;
        public string secondName;
        public string gender;
        public string birthCity;
        public string birthCityCode;
        public string birthDate;
        #endregion

        #region "Costruttore"
        // -------------------- Costruttore Vuoto --------------------
        public Person() : this("", "", "", "", "", "") { }

        // -------------------- Costruttore con Parametri --------------------
        public Person(string firstName, string secondName) : this(firstName, secondName, "", "", "", "") { }

        // -------------------- Costruttore con Parametri --------------------
        public Person(string firstName, string secondName, string gender) : this(firstName, secondName, gender, "", "", "") { }

        // -------------------- Costruttore con Parametri --------------------
        /// <summary>
        /// Costruttore della Classe Person
        /// </summary>
        /// <param name="firstName">First Name of the Person</param>
        /// <param name="secondName">Second Name of the Personparam>
        /// <param name="gender">Gender of the Person</param>
        /// <param name="birthCity">Birth City of the Person</param>
        /// <param name="birthCityCode">Birth City Code of the Person</param>
        /// <param name="birthDate">Birth Date of the Person</param>
        public Person(string firstName, string secondName, string gender, string birthCity, string birthCityCode, string birthDate) { 
            this.firstName = firstName;
            this.secondName = secondName;
            this.gender = gender;
            this.birthCity = birthCity;
            this.birthCityCode = birthCityCode;
            this.birthDate = birthDate;
        }
        #endregion

        #region "First Name - Second Name"
        // -------------------- Metodo che Setta il Nome --------------------
        public string setFirstName()
        {
            string firstName;

            Console.Write("First Name: ");
            firstName = Console.ReadLine();

            return firstName;
        }

        // -------------------- Metodo che Setta il Cognome --------------------
        public string setSecondName() {
            string secondName;

            Console.Write("Second Name: ");
            secondName = Console.ReadLine();

            return secondName;
        }
        #endregion

        #region "Gender"
        // -------------------- Metodo che Setta il Gender --------------------
        public string setGender()
        {
            string gender;

            do {
                Console.Write("Gender (M/F): ");
                gender = Console.ReadLine();
                gender = gender.ToUpper();
            } while (gender != "M" && gender != "F");

            return gender;
        }
        #endregion

        #region "Birth City - Birth City Code - Birth Date"
        // -------------------- Metodo che Setta il Birth City --------------------
        public string setBirthCity() {
            string birthCity;

            Console.Write("Birth City: ");
            birthCity = Console.ReadLine();

            return birthCity;
        }

        // -------------------- Metodo che Setta il Birth City Code --------------------
        public string setBirthCityCode()
        {
            string birthCityCode;

            Console.Write("Birth City Code: ");
            birthCityCode = Console.ReadLine();

            return birthCityCode;
        }
        
        // -------------------- Metodo che Setta il Birth Date --------------------
        public string setBirthDate()
        {
            string birthDate;

            Console.Write("Birth Date (XX-XX-XXXX): ");
            birthDate = Console.ReadLine();

            return birthDate;
        }
        #endregion

        #region "Start"
        // -------------------- Metodo che Lancia il Programma --------------------
        public void start() { 
            string firstName = this.setFirstName();
            string secondName = this.setSecondName();
            string gender = this.setGender();
            string birthCity = this.setBirthCity();
            string birthCityCode = this.setBirthCityCode();
            string birthDate = this.setBirthDate();
            
            Console.Write("\n" + firstName + " Age: " + this.getAge(birthDate));
            Console.WriteLine("\nCF: " + this.getFiscalCode(firstName, secondName, gender, birthCity, birthCityCode, birthDate));
        }
        #endregion

        #region "Get Age"
        // -------------------- Metodo che Restituisce l'Età --------------------
        public string getAge(string birthDate) {
            string age;
            DateTime data_odierna = DateTime.Today;
            DateTime data_nascita = Convert.ToDateTime(birthDate);

            int differenza_eta = data_odierna.Year - data_nascita.Year;
            if (data_nascita.Month > data_odierna.Month) {
                differenza_eta = differenza_eta - 1;
            } else if (data_nascita.Month == data_odierna.Month && data_nascita.Day > data_odierna.Day) {
                differenza_eta = differenza_eta - 1;
            } age = differenza_eta.ToString();

            return age;
        }
        #endregion

        #region "Get Fiscal Code"
        // -------------------- Metodo che Restituisce il Codice Fiscale --------------------
        public string getFiscalCode(string firstName, string secondName, string gender, string birthCity, string birthCityCode, string birthDate) {
            var parsedDate = DateTime.Parse(birthDate); 

            CodiceFiscaleUtility.CodiceFiscale CF = new CodiceFiscaleUtility.CodiceFiscale(secondName, firstName, gender, parsedDate, birthCity, birthCityCode);
            
            return CF.Codice;
        }
        #endregion
    }
}
