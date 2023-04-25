using Accord.Collections;
using MixTelematics.Helpers;
using MixTelematics.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace MixTelematics
{

    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FileHelper _fileHelper = new FileHelper();
        public MLHelpers _mlHelpers = new MLHelpers();
        public VehicleFinderHelper _vehicleFinderHelper = new VehicleFinderHelper();

        private static readonly (float Latitude, float Longitude)[] QueryCoordinates =
        {
            (34.544909f, -102.100843f),
            (32.345544f, -99.123124f),
            (33.234235f, -100.214124f),
            (35.195739f, -95.348899f),
            (31.895839f, -97.789573f),
            (32.895839f, -101.789573f),
            (34.115839f, -100.225732f),
            (32.335839f, -99.992232f),
            (33.535339f, -94.792232f),
            (32.234235f, -100.222222f)
        };



        

        


       


        public MainWindow()
        {
            InitializeComponent();


            
        }


        
        private void ShowMsgBox(object sender, RoutedEventArgs e)
        {
            try
            {
                var resultString = string.Empty;
                
                var vehiclePositions = _fileHelper.LoadVehiclePositions();
                var kdTree = _mlHelpers.BuildKdTree(vehiclePositions);

                foreach (var queryCoord in QueryCoordinates)
                {
                    var nearestVehicle = _vehicleFinderHelper.FindNearestVehicle(kdTree, queryCoord);
                    resultString = resultString + $"Closest vehicle to ({queryCoord.Latitude}, {queryCoord.Longitude}): ID {nearestVehicle.PositionId}, Position ({nearestVehicle.Latitude}, {nearestVehicle.Longitude})" + System.Environment.NewLine;
                }
                MessageBoxResult result = MessageBox.Show(resultString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            
        }

       
    }
}
