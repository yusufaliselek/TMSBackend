using System;

namespace TaskManagementSystemBackend.API.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class PermissionRequirementAttribute : Attribute
    {
        public string Permission { get; }

        public PermissionRequirementAttribute(string permission)
        {
            Permission = permission;
        }
    }
}
