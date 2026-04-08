using System.Collections.Generic;

namespace Detective.Models
{
    /// <summary>
    /// Тип следственного действия
    /// </summary>
    public class ActionType
    {
        /// <summary>
        /// Название действия (допрос, обыск, экспертиза)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код действия
        /// </summary>
        public string Code { get; set; }
    }

    /// <summary>
    /// Цель следственного действия
    /// </summary>
    public class Target
    {
        /// <summary>
        /// Идентификатор человека - цели
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Имя человека - цели
        /// </summary>
        public string PersonName { get; set; }
    }

    /// <summary>
    /// Результат следственного действия
    /// </summary>
    public class ActionResult
    {
        /// <summary>
        /// Краткое описание результата
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Полное описание результата
        /// </summary>
        public string FullText { get; set; }

        /// <summary>
        /// Дата проведения действия
        /// </summary>
        public string Date { get; set; }
    }

    /// <summary>
    /// Модель следственного действия
    /// </summary>
    public class InvestigativeAction
    {
        /// <summary>
        /// Уникальный идентификатор действия
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор дела
        /// </summary>
        public int CaseId { get; set; }

        /// <summary>
        /// Тип следственного действия
        /// </summary>
        public ActionType ActionType { get; set; }

        /// <summary>
        /// Цель следственного действия
        /// </summary>
        public Target Target { get; set; }

        /// <summary>
        /// Результат действия
        /// </summary>
        public ActionResult Result { get; set; }

        /// <summary>
        /// Список идентификаторов новых улик, обнаруженных в ходе действия
        /// </summary>
        public List<int> NewEvidences { get; set; }
    }
}