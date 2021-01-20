using Erebor.Service.Identity.Domain.Entities;
using Erebor.Service.Identity.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Erebor.Service.Identity.Domain.Test.Entities
{
    public class UserTest
    {
        private User user;
        public UserTest()
        {
            user = User.CreateUser(
                   new List<Email>() { new Email("berkayyerdelen@gmail.com"), new Email("berkayyerdelen1@gmail.com") },
                   new List<Role>() { new Role() { Value = "admin" }, new Role() { Value = "user" } },
                   "ubersecretpass","123",
                   DateTime.UtcNow,true);
        }
        [Fact]
        public void Should_Have_Create_User()
        {
            Assert.NotNull(user);
        }
        [Fact]
        public void Should_Have_Remove_Mail_From_MailList()
        {
            user.RemoveMail("berkayyerdelen@gmail.com");
            Assert.Equal("berkayyerdelen1@gmail.com", user.Emails.FirstOrDefault()?.Value);

        }
        [Fact]
        public void Should_Have_Throw_Exception_On_Adding_Existed_Mail()
        {
            var expectedMessage = "Email is already exist!";
            var exception = Assert.Throws<BusinessException>(() =>
            {
                user.AddMail(new Email("berkayyerdelen1@gmail.com"));
            });
            Assert.Equal(expectedMessage, exception.Message);
        }
        [Fact]
        public void Should_Have_Add_Mail_To_MailList()
        {
            user.AddMail(new Email("berkayyerdelen2@gmail.com"));
            Assert.Equal(3, user.Emails.Count);
        }
        [Fact]
        public void Should_Have_Throw_Email_Not_Found_Exception_In_Update_Mail()
        {
            var expectedMessage = "Email could not find!";
            var exception = Assert.Throws<BusinessException>(() =>
            {
                var entity = user.UpdateMail("berkayyerdelen100@gmail.com", "berkay@gmail.com");
            });
            Assert.Equal(expectedMessage, exception.Message);

        }
        [Fact]
        public void Should_Have_Update_Mail()
        {
            var entity = user.UpdateMail("berkayyerdelen@gmail.com", "berkay@gmail.com");
            Assert.Contains("berkay@gmail.com", entity.Emails.FirstOrDefault()?.Value ?? string.Empty);
        }
        [Fact]
        public void Should_Have_Clear_MailList()
        {
            var entity = user.ClearUserMailList();
            Assert.False(entity.Emails.Any());
        }
        [Fact]
        public void Should_Have_Add_Role()
        {
            user.AddRole(new List<Role>() { new Role() { Value = "superadmin" } });
            Assert.Equal(3, user.Roles.Count);
        }
        [Fact]
        public void Should_Have_Throw_Exception_For_Existing_Role_In_Adding_Role()
        {
            var exception = Assert.Throws<BusinessException>(() =>
            {
                user.AddRole(new List<Role>() { new Role() { Value = "admin" } });
            });
        }
        [Fact]
        public void Should_Have_Remove_Roles()
        {
            user.RemoveRoles(new List<Role>() { new Role() { Value = "admin" } });
            var count = user.Roles.Count;
            Assert.Equal(1, count);
        }
        [Fact]
        public void Should_Have_Update_Role()
        {
            user.UpdateRole(new Role() { Value = "admin" }, "superadmin");
            Assert.Contains(user.Roles, x => x.Value == "superadmin");
        }
        [Fact]
        public void Should_Have_Activate_User()
        {
            user.ActivateUser();
            Assert.True(user.IsActive);
        }
        [Fact]
        public void Should_Have_DeActivate_User()
        {
            user.DeActivateUser();
            Assert.False(user.IsActive);
        }
    }
}
