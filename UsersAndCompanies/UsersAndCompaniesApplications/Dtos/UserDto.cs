﻿namespace UsersAndCompaniesApplications.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }
    }
}
