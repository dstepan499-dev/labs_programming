using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice4
{
    public class Student
    {
        private string lastName;
        private string firstName;
        private string patronymic;
        private DateTime dateOfBirth;
        private int course;
        private string group;

        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Фамилия не может быть пустой.");
                lastName = value;
            }
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Имя не может быть пустым.");
                firstName = value;
            }
        }

        public string Patronymic
        {
            get => patronymic;
            set => patronymic = value;
        }

        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set
            {
                if (value > DateTime.Now.AddYears(-16))
                    throw new ArgumentException("Некорректная дата рождения.");
                dateOfBirth = value;
            }
        }

        public int Course
        {
            get => course;
            set
            {
                if (value < 1 || value > 6)
                    throw new ArgumentException("Курс должен быть в диапазоне от 1 до 6.");
                course = value;
            }
        }

        public string Group
        {
            get => group;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Группа не может быть пустой.");
                group = value;
            }
        }

        public Student(string lastName, string firstName, string patronymic, DateTime dateOfBirth, int course, string group)
        {
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
            Course = course;
            Group = group;
        }

        public override string ToString()
        {
            return $"Студент: {LastName} {FirstName} {Patronymic}, Дата рождения: {DateOfBirth:dd.MM.yyyy}, Курс: {Course}, Группа: {Group}";
        }
    }
}

