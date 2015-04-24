using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Form337Insertion.Models;

namespace Form337Insertion.Services
{
    class ProfileService
    {
        public static ProfileModel GetProfile(string profileName)
        {
            return new ProfileModel();
        }

        public static bool SaveProfile(ProfileModel profileToSave, string profileLocation)
        {
            try
            {
                SerializeProfile(profileToSave, profileLocation);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }
        }

        public static List<ProfileModel> LoadProfiles(string profileLocation)
        {
            string[] fileArray = Directory.GetFiles(profileLocation, "*.xml");
            foreach(string file in fileArray)
            {
                try
                {
                    LoadFileIntoProfile(file);
                }
                catch(Exception ex)
                {
                    Console.Write(ex);
                }
            }
            return new List<ProfileModel>();
        }

        public static ProfileModel LoadFileIntoProfile(string profileLocation)
        {
            try
            {
                return DeserializeProfile(profileLocation);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return new ProfileModel();
            }
        }

        private static void SerializeProfile(ProfileModel profile, string profileLocation)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProfileModel));
            using (TextWriter writer = new StreamWriter(profileLocation))
            {
                serializer.Serialize(writer, profile);
            }
        }

        private static ProfileModel DeserializeProfile(string profileLocation)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(ProfileModel));
            ProfileModel loadedProfile;
            using (TextReader reader = new StreamReader(profileLocation))
            {
                object obj = deserializer.Deserialize(reader);
                loadedProfile = (ProfileModel)obj;
            }
            return loadedProfile;
        }
    }
}
