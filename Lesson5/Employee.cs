using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
{
    class Employee
    {

        public string fio { get; set; }
        public string post { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public int paycheck { get; set; }
        public int age { get; set; }

        public Employee(string FIO, string Post, string Email, string PhoneNumber, int Paycheck, int Age )
        {
            fio = FIO;
            post = Post;
            email = Email;
            phoneNumber = PhoneNumber;
            paycheck = Paycheck;
            age = Age;
        }
        public Employee()
        {

        }

        public void list()
        { Console.WriteLine(this); }
        public override string ToString()
        {
            return $"{fio} {post} возраст:{age} зарплата:{paycheck}р тел:{phoneNumber} почта:{email}";
        }


    }
}
