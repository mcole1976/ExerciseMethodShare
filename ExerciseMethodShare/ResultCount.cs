using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseMethodShare
{
    public class ResultCount
    {
        private string _exercise_category;
        private string _exercise_name;
        private int _excount;
        private bool _verified;

        public string Exercise_category { get => _exercise_category; set => _exercise_category = value; }
        public string Exercise_name { get => _exercise_name; set => _exercise_name = value; }
        public int Excount { get => _excount; set => _excount = value; }
    }
}
