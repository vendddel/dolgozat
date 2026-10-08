using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dolgozat
{
    internal record Auto(string Brand, string Type, int Hp, string Owner)
    {
        private int _price { get; set; }
        public double Rating { get; set; }
        private double _averageConumption { get; set; }
        public string _owner { get; init; } = Owner;

        public double GetAverageConsumtion()
        { return _averageConumption; }

        public int GetPrice() { return _price; }
        public string GetOwner() { return _owner; }

        public void SetAverageConsumption(double avgcons)
        {
            _averageConumption = avgcons;
        }

        public void SetPrice(int price)
        {
            _price = price;
        }


        public bool IsStrong()
        {
            return Hp >= 200;
        }


        public bool IsGoodRating()
        {
            return Rating >= 8.5;
        }

        public bool OverMaxPrice(int maxprice)
        {
            return _price > maxprice;
        }

        //4szazalekos

        //5
        public double FuelConsumption(double km)
        {

            return (_averageConumption / 100) * km;
        }

        public double TripCost(double fuelprice, double km)
        {

            return _averageConumption / fuelprice * km;
        }

        public void UpdateRating(double newRating)
        {

            if (newRating > 1 && newRating < 10)
            {
                Rating = newRating;
            }
        }

        public override string ToString()
        {
            return $"Az autót a {Brand} cég gyártotta, ez a {Type} típusú, {_owner} a gazdája és {_price} forintba került";
        }

    }
}
