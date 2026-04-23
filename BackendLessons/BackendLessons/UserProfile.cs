using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLessons
{
    internal class UserProfile : Admin
    {
        //Field
        private int _id; // Resolve question about belongs instance or it is out of context ()
        private const int _age = 30;   // you can't change
        private readonly int _code = 85; // you can only or assign a value in the constructor

        //Properties
        public int Id { get { return _id; } set { _id = value + 5; } }

        public string Name { get; set; }

        //Constructor
        public UserProfile(int id, int code)
        {
            _id = id;
            _code = code;
        }

        private void ShowMessage()
        {
            
        }

        public void MaskMessage()
        {
            Authorize();
        }

        public static void Test()
        {
        }
    }

    public static class Calculator
    {
        public static void Calculate()
        {

        }
    }
}
