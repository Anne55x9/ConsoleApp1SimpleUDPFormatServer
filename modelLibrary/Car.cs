using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelLibrary
{
    public class Car
    {
        private string model;

        private string color;

        private string regNo;

        /// <summary>
        /// properties hvor grænser kan sættes med if statement.
        /// </summary>

        public string Model { get => model; set => model = value; }
        public string Color { get => color; set => color = value; }
        public string RegNo { get => regNo; set => regNo = value; }

        /// <summary>
        /// Default construktor.
        /// </summary>

        public Car():this("DummyModel", "DummeColor", "DummyRegNo")
        {
            
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="model"></param>
        /// <param name="color"></param>
        /// <param name="regNo"></param>
        public Car(string model, string color, string regNo)
        {
            this.model = model;
            this.color = color;
            this.regNo = regNo;
        }

        public override string ToString()
        {
            return $"{nameof(Model)}:{Model}, {nameof(Color)}: {Color}, {nameof(RegNo)}: {RegNo}";
        }
    }
}
