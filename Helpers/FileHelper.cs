using MixTelematics.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MixTelematics.MainWindow;

namespace MixTelematics.Helpers
{
    public class FileHelper
    {

        public FileHelper()
        {

        }
        public  VehicleData[] LoadVehiclePositions()
        {
            try
            {
                string fileName = "VehiclePositions.dat";
                string rootPath = AppDomain.CurrentDomain.BaseDirectory;
                string fullPath = Path.Combine(rootPath, "assets", fileName);
                using var fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                using var binaryReader = new BinaryReader(fileStream);

                int recordSize = 4 + 256 + 4 + 4 + 8; // 4 bytes for PositionId, 256 bytes for VehicleRegistration, 4 bytes for Latitude, 4 bytes for Longitude, 8 bytes for RecordedTimeUTC
                int recordCount = (int)(fileStream.Length / recordSize);
                var vehiclePositions = new VehicleData[recordCount];

                for (var i = 0; i < recordCount; i++)
                {
                    vehiclePositions[i] = new VehicleData
                    {
                        PositionId = binaryReader.ReadInt32(),
                        VehicleRegistration = ReadNullTerminatedString(binaryReader),
                        Latitude = binaryReader.ReadSingle(),
                        Longitude = binaryReader.ReadSingle(),
                        RecordedTimeUTC = DateTimeOffset.FromUnixTimeSeconds((long)binaryReader.ReadUInt64()).UtcDateTime
                    };
                }

                return vehiclePositions;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }

            
        }


        public string ReadNullTerminatedString(BinaryReader reader)
        {
            var chars = new List<char>();
            char currentChar;

            while ((currentChar = reader.ReadChar()) != '\0')
            {
                chars.Add(currentChar);
            }

            return new string(chars.ToArray());
        }
    }
}
