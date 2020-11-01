using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;

namespace IndianStateCensusAnalyser_NUnitTest
{
    public class Tests
    {
        static string wrongIndiaStateCensusData = @"G:\Programming\Bridge Labz\04 C# IO Streams\03_CensusAnalyzer_DesignPrinciples\IndianStateCensusAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";
        static string wrongIndiaStateCode = @"G:\Programming\Bridge Labz\04 C# IO Streams\03_CensusAnalyzer_DesignPrinciples\IndianStateCensusAnalyser\CSVFiles\WrongIndiaStateCode.csv";
        static string indiaStateCensusData = @"G:\Programming\Bridge Labz\04 C# IO Streams\03_CensusAnalyzer_DesignPrinciples\IndianStateCensusAnalyser\CSVFiles\IndiaStateCensusData.csv";
        static string indiaStateCode = @"G:\Programming\Bridge Labz\04 C# IO Streams\03_CensusAnalyzer_DesignPrinciples\IndianStateCensusAnalyser\CSVFiles\IndiaStateCode.csv";
        static string delimiterIndiaStateCensusData = @"G:\Programming\Bridge Labz\04 C# IO Streams\03_CensusAnalyzer_DesignPrinciples\IndianStateCensusAnalyser\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string delimiterIndiaStateCode = @"G:\Programming\Bridge Labz\04 C# IO Streams\03_CensusAnalyzer_DesignPrinciples\IndianStateCensusAnalyser\CSVFiles\DelimiterIndiaStateCode.csv";
        static string indiaStateCodeText = @"G:\Programming\Bridge Labz\04 C# IO Streams\03_CensusAnalyzer_DesignPrinciples\IndianStateCensusAnalyser\CSVFiles\IndiaStateCode.txt";
        static string indiaStateCensusDataText = @"G:\Programming\Bridge Labz\04 C# IO Streams\03_CensusAnalyzer_DesignPrinciples\IndianStateCensusAnalyser\CSVFiles\IndiaStateCensusDAta.txt";
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        /// <summary>
        /// Set up will always run, when any test case is checked.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();

        }
        /// <summary>
        /// Test Case 1.1
        /// Getting the count of data in IndiaStateCensusData
        /// </summary>

        [Test]
        public void GivenIndianCensusDataFile_WhenReturnShouldReturnCensusDataCount()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indiaStateCensusData, indianStateCensusHeaders);
            //assert
            //total no of rows excluding header are 29 in indian state census data.
            Assert.AreEqual(29, totalRecord.Count);
        }

        [Test]
        /// <summary>
        /// checking the program for incorrect file name which do not exist
        /// test case 1.2
        /// </summary>
        public void GivenWrongIndianCensusDataFile_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndiaStateCensusData, indianStateCensusHeaders));
            //total no of rows excluding header are 29 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.Exception.FILE_NOT_FOUND, customException.exception);
        }

        /// <summary>
        /// checking the program for incorrect file type which do not exist
        /// test case 1.3
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataType_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indiaStateCensusDataText, indianStateCensusHeaders));
            //total no of rows excluding header are 29 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.Exception.INVALID_FILE_TYPE, customException.exception);
        }

        /// <summary>
        /// checking the program for incorrect delimiter is passed
        /// test case 1.4
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiterForCensusData_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimiterIndiaStateCensusData, indianStateCensusHeaders));
            //total no of rows excluding header are 29 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.Exception.INCOREECT_DELIMITER, customException.exception);
        }

        /// <summary>
        /// checking the program for incorrect header is passed
        /// test case 1.5
        /// </summary>
        [Test]
        public void GivenIncorrectHeaderForCensusData_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndiaStateCensusData, indianStateCensusHeaders));
            //total no of rows excluding header are 29 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_HEADER, customException.exception);
        }
    }
}