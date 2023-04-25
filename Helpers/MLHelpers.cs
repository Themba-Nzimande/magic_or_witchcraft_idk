using Accord.Collections;
using MixTelematics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MixTelematics.MainWindow;

namespace MixTelematics.Helpers
{
    public class MLHelpers
    {
        public KDTree<VehicleData> BuildKdTree(VehicleData[] vehiclePositions)
        {
            try
            {
                var kdTree = new KDTree<VehicleData>(2);

                foreach (var vehicle in vehiclePositions)
                {
                    kdTree.Add(new double[] { vehicle.Latitude, vehicle.Longitude }, vehicle);
                }

                return kdTree;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            
        }


       
    }
}
