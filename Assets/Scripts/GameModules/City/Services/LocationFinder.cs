using City.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace City.Services 
{
    public class LocationFinder
    {
        public Vector2 FindMapLocation(string location, ICityModel model)
        {
            Vector2 spawnPosition;
            if (location.Contains(","))
            {
                var split = location.Split(",");
                spawnPosition = new Vector2Int(int.Parse(split[0].Trim()), int.Parse(split[0].Trim()));
            }
            else
            {
                var b = model.Buildings.GetItem(location);
                spawnPosition = b.EntrancePosition;
            }
            return spawnPosition;
        }
    }
}