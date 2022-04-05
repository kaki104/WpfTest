using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargeFileReadSample
{
    //"ID,Case Number,Date,Block,IUCR,Primary Type,Description,Location Description,Arrest,Domestic,Beat,District,Ward,Community Area,FBI Code,
    //X Coordinate,Y Coordinate,Year,Updated On,Latitude,Longitude,Location"

    public class SampleDataModel
    {
        public string ID { get; set; }
        public string CaseNumber { get; set; }
        public string Date { get; set; }
        public string Block { get; set; }
        public string IUCR { get; set; }
        public string PrimaryType { get; set; }
        public string Description { get; set; }
        public string LocationDescription { get; set; }
        public string Arrest { get; set; }
        public string Domestic { get; set; }
        public string Beat { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string CommunityArea { get; set; }
        public string FBICode { get; set; }
        public string XCoordinate { get; set; }
        public string YCoordinate { get; set; }
        public string Year { get; set; }
        public string UpdatedOn { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Location { get; set; }
    }
}
