using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseMethodShare
{
    public class WorkOut
    {
        private string _name;
        private int _time;
        private bool _complete;
        private int _id;



        public string Name { get => _name; set => _name = value; }
        public int Time { get => _time; set => _time = value; }
        public bool Complete { get => _complete; set => _complete = value; }
        public int Id { get => _id; set => _id = value; }
    }
}
