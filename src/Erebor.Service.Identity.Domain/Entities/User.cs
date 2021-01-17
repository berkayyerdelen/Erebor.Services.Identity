using Erebor.Service.Identity.Domain.Entities.Base;
using Erebor.Service.Identity.Domain.Events;
using Erebor.Service.Identity.Domain.Exceptions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Domain.Entities
{
    public class User : AggregateRoot
    {
        public List<Email> Emails { get; set; }
        public List<Role> Roles { get; private set; }
        public string UserName { get; set; }
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsActive { get; private set; }
       
        protected User(Guid id,List<Email> emails, List<Role> roles, string userName ,string password, DateTime createdAt, bool isActive)
        {
            Id = id;
            Emails = emails;
            Roles = roles;
            UserName = userName;
            IsActive = true;
            CreatedAt = createdAt;
            IsActive = isActive;
            AddEvent(new CreateUserEvent(roles, emails, userName,password, createdAt,isActive));
        }
        public static User CreateUser(AggregateId id,List<Email> emails, List<Role> roles, string userName, string password, DateTime createdAt, bool isActive)
            => new User(id,emails, roles, userName,password, createdAt,isActive);
        public User RemoveMail(string email)
        {
            var mail = Emails.FirstOrDefault(x => x.Value == email);
            Emails.Remove(mail);
            return this;
        }
        public User AddMail(Email email)
        {
            if (Emails.Any(x => x.Value == email.Value))
            {
                throw new BusinessException("Email is already exist!");
            }
            Emails.Add(email);
            return this;
        }
        public User UpdateMail(string email, string value)
        {
            var mail = Emails.FirstOrDefault(x => x.Value == email);
            if (mail == null)
            {
                throw new BusinessException("Email could not find!");
            }
            mail.Value = value;
            return this;
        }
        public User ClearUserMailList()
        {
            Emails.Clear();
            return this;
        }
        public User AddRole(List<Role> roles)
        {
            var IsValid = Role.IsValid(roles);
            if (!IsValid)
                throw new BusinessException("Role is not valid!");
            else
                roles.ForEach(role =>
                {
                    if (Roles.Any(x => x.Value == role.Value))
                    {
                        throw new BusinessException($"This {role.Value} role is already given the user!");
                    }
                    Roles.Add(role);
                });
            AddEvent(new AddRoleEvent(roles));
            return this;
        }
        public User RemoveRoles(List<Role> roles)
        {
            var isValid = Role.IsValid(roles);
            if (isValid)
            {
                roles.ForEach(role =>
                {
                    var subRole = Roles.FirstOrDefault(x => x.Value == role.Value);
                    Roles.Remove(subRole);
                });
            }
            AddEvent(new RemoveRolesEvent(roles));
            return this;
        }
        public User UpdateRole(Role role, string value)
        {
            var isValid = Role.IsValid(role);
            if (isValid)
            {
                var userRole = Roles.FirstOrDefault(x => x.Value == role.Value);
                userRole.Value = value;
            }
            AddEvent(new UpdateRoleEvent(value, role));
            return this;
        }
        public User UpdatePassword(string password)
        {
            if (!string.IsNullOrEmpty(password))
                Password = password;
            AddEvent(new UpdatePasswordEvent(password));
            return this;
        }
        public User ActivateUser()
        {
            IsActive = true;
            AddEvent(new ActivateUserEvent(IsActive));
            return this;
        }
        public User DeActivateUser()
        {
            IsActive = false;
            AddEvent(new DeActivateUserEvent(IsActive));
            return this;
        }

    }
}
