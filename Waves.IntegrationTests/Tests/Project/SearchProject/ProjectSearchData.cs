using System;
using System.Collections;
using System.Collections.Generic;
using Waves.Services.Models;

namespace Waves.IntegrationTests.Tests.Project.SearchProject
{
    public class ProjectSearchData : IEnumerable<Object[]>
    {
        public IEnumerator<Object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }

        private readonly List<Object[]> _data = new List<Object[]>
        {
            new Object[]
            {
                new ProjectSearchParametersModel
                {
                    Page = 1,
                    PerPage = 20,
                    IsActive = true
                },
                5
            },
            new Object[]
            {
                new ProjectSearchParametersModel
                {
                    Page = 1,
                    PerPage = 20,
                    IsActive = false
                },
                2
            },
            new Object[]
            {
                new ProjectSearchParametersModel
                {
                    Page = 1,
                    PerPage = 20,
                    ProjectId = 2,
                    IsActive = false
                },
                1
            },
            new Object[]
            {
                new ProjectSearchParametersModel
                {
                    Page = 1,
                    PerPage = 20,
                    UserId = 1,
                    IsActive = true
                },
                3
            },
            new Object[]
            {
                new ProjectSearchParametersModel
                {
                    Page = 1,
                    PerPage = 20,
                    SearchTerm = "test",
                    IsActive = true
                },
                1
            },
            new Object[]
            {
                new ProjectSearchParametersModel
                {
                    Page = 1,
                    PerPage = 20,
                    SearchTerm = "no"
                },
                0
            },
            new Object[]
            {
                new ProjectSearchParametersModel
                {
                    Page = 1,
                    PerPage = 20,
                    SearchTerm = "Marinara",
                    UserId = 2,
                    IsActive = true
                },
                1
            },
            new Object[]
            {
                new ProjectSearchParametersModel
                {
                    Page = 1,
                    PerPage = 20,
                    IsActive = false,
                    UserId = 2
                },
                0
            },
        };
    }
}
