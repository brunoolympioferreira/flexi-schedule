﻿namespace FlexiSchedule.Domain.Entities;
public class Professional : BaseEntity
{
    public string Name { get; private set; }
    public string Company { get; private set; }
    public DocumentTypeEnum DocumentType { get; private set; }
    public string Document { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string Phone { get; private set; }

    public Professional(string name, string company, DocumentTypeEnum documentType, string document, string email, string passwordHash, string phone)
    {
        Name = name;
        Company = company;
        DocumentType = documentType;
        Document = document;
        Email = email;
        PasswordHash = passwordHash;
        Phone = phone;
    }
}
