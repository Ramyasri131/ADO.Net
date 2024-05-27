﻿using EmployeeDirectory.BAL.Interfaces;
using EmployeeDirectory.DAL.Interfaces;


namespace EmployeeDirectory.BAL.Providers
{
    public class LocationProvider(ILocationRepository LocationRepository) : ILocationProvider
    {
        public static Dictionary<int, string> Location = new();
        private readonly ILocationRepository _LocationRepository = LocationRepository;

        public void GetLocations()
        {
            Location = _LocationRepository.GetLocations();
        }
    }
}
