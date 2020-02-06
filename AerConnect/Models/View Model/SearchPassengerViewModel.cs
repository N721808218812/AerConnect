using AerConnect.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AerConnect.Models.View_Model
{
    public class SearchPassengerViewModel
    {
        public List<Putnik> Putniks { get; set; }
        public SearchPassanger search { get; set; }
    }
}