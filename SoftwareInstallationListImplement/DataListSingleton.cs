using System;
using SoftwareInstallationListImplement.Models;
using System.Collections.Generic;

namespace SoftwareInstallationListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Component> Components { get; set; }

        public List<Order> Orders { get; set; }

        public List<Package> Packages { get; set; }

        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Packages = new List<Package>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
