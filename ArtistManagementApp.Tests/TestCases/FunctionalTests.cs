﻿
using ArtistManagementApp.DAL.Interface;
using ArtistManagementApp.DAL.Repository;
using ArtistManagementApp.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using ArtistManagementApp.Tests.TestCases;

namespace ArtistManagementApp.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IArtistInterface _artistService;
        public readonly Mock<IArtistRepository> artistservice = new Mock<IArtistRepository>();
        private readonly Artist _Artist;
        private readonly IEnumerable<Artist> ArtistList;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            _artistService = new ArtistManagementService(artistservice.Object);
            _output = output;
            _Artist = new Artist
            {
                ArtistId = 1,
                FirstName = "Vicky",
                LastName = "Patel",
                DateOfBirth = DateTime.Now.Date,
                Email = "V@gmail.cm"
            };
            ArtistList = new List<Artist>
        {
            new Artist
            {
               ArtistId = 1,
                FirstName = "Vicky",
                LastName = "Patel",
                DateOfBirth = DateTime.Now.Date,
                Email = "V@gmail.cm"
            },
            new Artist
            {
              ArtistId = 1,
                FirstName = "Vicky",
                LastName = "Patel",
                DateOfBirth = DateTime.Now.Date,
                Email = "V@gmail.cm"
            },
            // Add more Artist instances as needed
        };

        }


        [Fact]
        public async Task<bool> Testfor_Get_Artist()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                  artistservice.Setup(repos => repos.GetAllArtists()).Returns(ArtistList);
                var result =   _artistService.GetAllArtists();
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Get_Artist_ById()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                 artistservice.Setup(repos => repos.GetArtistById(_Artist.ArtistId)).Returns(_Artist);
                var result =  _artistService.GetArtistById(_Artist.ArtistId);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Update_Artist()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                 artistservice.Setup(repos => repos.UpdateArtist(_Artist)).Returns(_Artist);
                var result= _artistService.UpdateArtist(_Artist);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Delete_Artist()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                 artistservice.Setup(repos => repos.DeleteArtist(_Artist.ArtistId)).Returns(_Artist);
                var result= _artistService.DeleteArtist(_Artist.ArtistId);

                //Assertion
                if (result!= null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}