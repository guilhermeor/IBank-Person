using Xunit;
using System;
using System.Collections.Generic;
using Person.Domain;
using FluentAssertions;
using Person.Domain.ValueObjects;

namespace Person.Tests.Core
{
    public partial class PersonTest
    {
        public PersonTest()
        {

        }

        [Fact]
        public void Should_be_valid_when_Data_is_valid()
        {
            var firstName = "Guilherme";
            var lastName = "Rosa";
            var person = new Domain.Person(new Name(firstName, lastName), DateTime.Now);

            person.Name.FirstName.Should().Be(firstName);
            person.Name.LastName.Should().Be(lastName);      
        }
    }
}

