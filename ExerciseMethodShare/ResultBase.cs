using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseMethodShare
{
    public class ResultBase
    {
        string _name;
        string _exercise_Name;
        string _searched_exercise;
        string _exercise_type;
        bool _match;
        bool _fullMatch;
        int _rank;
        string _name_Match;

        public string Action { get => _name; set => _name = value; }
        public string Exercise_Name { get => _exercise_Name; set => _exercise_Name = value; }
        public bool Match { get => _match; set => _match = value; }
        public bool FullMatch { get => _fullMatch; set => _fullMatch = value; }
        public string Name_Match { get => _name_Match; set => _name_Match = value; }
        public int Rank { get => _rank; set => _rank = value; }
        public string Searched_exercise { get => _searched_exercise; set => _searched_exercise = value; }
        public string Exercise_Type { get => _exercise_type; set => _exercise_type = value; }
    }
}
