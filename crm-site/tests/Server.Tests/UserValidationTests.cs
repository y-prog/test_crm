using Xunit;
using server.Classes;
using server.Enums;
using System;

public class UserValidationTests
{
    [Fact]
    public void User_Creation_Should_Assign_Properties_Correctly()
    {
        // Arrange
        int id = 1;
        string username = "testuser";
        Role role = Role.ADMIN; 
        int companyId = 101;
        string company = "Test Company";

        // Act
        var user = new User(id, username, role, companyId, company);

        // Assert
        Assert.Equal(id, user.Id);
        Assert.Equal(username, user.Username);
        Assert.Equal(role, user.Role);
        Assert.Equal(companyId, user.CompanyId);
        Assert.Equal(company, user.Company);
    }

    [Fact]
    public void Username_Should_Not_Be_Empty()
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new User(1, "", Role.ADMIN, 101, "Test Company"));
        Assert.Equal("Username should not be empty.", exception.Message);
    }

    [Fact]
    public void Role_Should_Be_Valid()
    {
        // Arrange
        var validRole = Role.ADMIN;
        var invalidRole = (Role)999; // Invalid role value

        // Act & Assert
        var validUser = new User(1, "testuser", validRole, 101, "Test Company");
        Assert.Equal(validRole, validUser.Role);

        // Check that the exception message includes "(Parameter 'role')"
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new User(1, "testuser", invalidRole, 101, "Test Company"));
        Assert.Equal("Invalid role specified. (Parameter 'role')", exception.Message);
    }

    [Fact]
    public void Company_Should_Not_Be_Empty()
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new User(1, "testuser", Role.ADMIN, 101, ""));
        Assert.Equal("Company name should not be empty.", exception.Message);
    }
}