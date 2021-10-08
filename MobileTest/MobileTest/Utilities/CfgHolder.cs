using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MobileTest
{
    public class CfgHolder
    {
        private readonly XDocument _xDocument;
        public CfgHolder(XDocument xDocument)
        {
            _xDocument = xDocument;
        }

        public List<Camera> GetChannels()
        {
            var channels = _xDocument.Element("Configuration").Element("Channels").Elements("ChannelInfo");
            var camerasList = new List<Camera>();
            foreach (var channel in channels)
            {
                var cameraId = Guid.Parse(channel.Attribute("Id").Value);
                var cameraSecObjectInfoName = GetRootObj(cameraId);
                var cameraName = channel.Attribute("Name").Value;
                var cameraIsSoundOn = Convert.ToBoolean(channel.Attribute("IsSoundOn").Value);
                camerasList.Add(new Camera(cameraName, cameraIsSoundOn, cameraSecObjectInfoName, cameraId));
            }
            return camerasList;
        }
        private string GetRootObj(Guid channelId)
        {
            var channelsId = _xDocument.Element("Configuration").Element("RootSecurityObject")
                .Element("ChildSecurityObjects").Elements("SecObjectInfo").Elements("ChildChannels").Elements("ChannelId");
            var cameraSecObjectInfoName = channelsId.Where(x => x.Value == channelId.ToString()).ToList()[0]
                .Parent.Parent.Attribute("Name").Value;
            return cameraSecObjectInfoName;
        }
    }
}
