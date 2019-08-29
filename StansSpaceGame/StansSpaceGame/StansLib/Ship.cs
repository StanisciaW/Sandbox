using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StansLib
{
    public class Ship
    {
        public Ship(string model)
        {
            if (model == "Collosus")
            {
                this.modelName = model;
                this.price = 1000;
                this.cargoCapacity = 50;
            }
            else if (model == "SpitFire")
            {
                this.modelName = model;
                this.price = 2000;
                this.cargoCapacity = 100;
            }
        }

        private string modelName;
        private int price;
        private int cargoCapacity;

        public string GetModelName() => modelName;
        public int GetPrice() => price;
        public int GetCargoCapacity() => cargoCapacity;

    }
}

