using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargeFileReadSample
{
    //"ID,Case Number,Date,Block,IUCR,Primary Type,Description,Location Description,Arrest,Domestic,Beat,District,Ward,Community Area,FBI Code,
    //X Coordinate,Y Coordinate,Year,Updated On,Latitude,Longitude,Location"

    public partial class SampleDataModel2 : ObservableValidator
    {
        [ObservableProperty]
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        private string _iD;
        //public string ID { get; set; }
        [ObservableProperty]
        private string _caseNumber;
        //public string CaseNumber { get; set; }
        [ObservableProperty]
        private string _date;
        //public string Date { get; set; }
        [ObservableProperty]
        private string _block;
        //public string Block { get; set; }
        [ObservableProperty]
        private string _iUCR;
        //public string IUCR { get; set; }
        [ObservableProperty]
        private string _primaryType;
        //public string PrimaryType { get; set; }
        [ObservableProperty]
        private string _description;
        //public string Description { get; set; }
        [ObservableProperty]
        private string _locationDescription;
        //public string LocationDescription { get; set; }
        [ObservableProperty]
        private string _arrest;
        //public string Arrest { get; set; }
        [ObservableProperty]
        private string _domestic;
        //public string Domestic { get; set; }
        [ObservableProperty]
        private string _beat;
        //public string Beat { get; set; }
        [ObservableProperty]
        private string _district;
        //public string District { get; set; }
        [ObservableProperty]
        private string _ward;
        //public string Ward { get; set; }
        [ObservableProperty]
        private string _communityArea;
        //public string CommunityArea { get; set; }
        [ObservableProperty]
        private string _fBICode;
        //public string FBICode { get; set; }
        [ObservableProperty]
        private string _xCoordinate;
        //public string XCoordinate { get; set; }
        [ObservableProperty]
        private string _yCoordinate;
        //public string YCoordinate { get; set; }
        [ObservableProperty]
        private string _year;
        //public string Year { get; set; }
        [ObservableProperty]
        private string _updateOn;
        //public string UpdatedOn { get; set; }
        [ObservableProperty]
        private string _latitude;
        //public string Latitude { get; set; }
        [ObservableProperty]
        private string _longitude;
        //public string Longitude { get; set; }
        [ObservableProperty]
        private string _location;
        //public string Location { get; set; }
    }
}
