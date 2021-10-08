using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileTest
{
    public class Camera
    {
        public Image Frame { get; set; }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool DisplayFrame { get; set; }
        public bool IsSoundOn { get; set; }

        public string SecObjectInfoName { get; set; }

        public Camera(string name, bool isSoundOn, string secObjectInfoName, Guid id)
        {
            Id = id;
            Name = name;
            IsSoundOn = isSoundOn;
            SecObjectInfoName = secObjectInfoName;
            Frame = new Image();
        }
    }
}
