using City.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using City.Model;
using Model;

namespace City.Commands
{
    public class BuildRoadCommand : ICommand
    {
        static CityGenerator _cityGenerator = new CityGenerator();

        string _startName;
        Vector2Int _start;
        string _endName;
        Vector2Int _end;

        public BuildRoadCommand(string startName, string endName)
        {
            _startName = startName;
            _endName = endName;
        }

        public BuildRoadCommand(Vector2Int start, Vector2Int end)
        {
            _start = start;
            _end = end;
        }

        public void Execute(GameModel model)
        {
            if (string.IsNullOrEmpty(_startName))
            {
                _cityGenerator.BuildRoad(model.GetModel<CityModel>(), _start, _end, true);
            }
            else
            {
                _cityGenerator.BuildRoad(model.GetModel<CityModel>(), _startName, _endName);
            }
        }
    }
}