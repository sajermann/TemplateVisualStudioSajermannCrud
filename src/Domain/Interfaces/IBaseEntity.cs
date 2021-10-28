using System;

namespace $ext_rootnamespace$.$safeprojectname$.Interfaces
{
    public class IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool IsBlocked { get; set; } = false;
        public bool IsActive { get; set; } = true;
  }
}
