using System;

namespace TaskManagementSystemBackend.API.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class OrganizationUserValidationAttribute: Attribute
    {
    }
}
