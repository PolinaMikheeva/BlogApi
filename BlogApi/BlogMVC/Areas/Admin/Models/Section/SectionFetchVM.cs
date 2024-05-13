using System.ComponentModel.DataAnnotations;

namespace BlogMVC.Areas.Admin.Models.Section
{
    public class SectionFetchVM
    {
        
        /// <summary>
        /// Идентификатор раздела
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Код раздела
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Название раздела
        /// </summary>
        public string Name { get; set; }
        
    }
}
