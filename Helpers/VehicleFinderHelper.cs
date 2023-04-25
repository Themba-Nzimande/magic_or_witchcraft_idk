using Accord.Collections;
using MixTelematics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixTelematics.Helpers
{
    public class VehicleFinderHelper
    {
        public VehicleData FindNearestVehicle(KDTree<VehicleData> kdTree, (float Latitude, float Longitude) queryCoord)
        {
            var queryPoint = new double[] { queryCoord.Latitude, queryCoord.Longitude };
            var nearestNode = kdTree.Nearest(queryPoint);
            return nearestNode.Value;
        }
    }
}
