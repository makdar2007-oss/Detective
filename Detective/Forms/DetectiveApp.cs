using Detective.DTO;
using System.Drawing;
using Detective.Forms;
using Detective.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Detective
{ 
  /// <summary>
  /// Главная форма приложения "Детективное агентство"
  /// </summary>
    public partial class DetectiveApp : Form
    {
        private DetectiveData currentData;

        public DetectiveApp()
        {
            InitializeComponent();
            treeViewdetective.AfterSelect += TreeViewdetective_AfterSelect;

            dataGridViewDetective.Font = new Font("Segoe UI", 11);
            dataGridViewDetective.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 14, FontStyle.Bold);
        }

        private void TreeViewdetective_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var entityType = e.Node.Name;
            LoadDataToGrid(entityType);
        }

        private void LoadDataToGrid(string entityType)
        {
            if (currentData == null) return;

            dataGridViewDetective.SuspendLayout();

            try
            {
                dataGridViewDetective.DataSource = null;

                switch (entityType)
                {
                    case "Persons":
                        dataGridViewDetective.DataSource = currentData.Persons?
                            .Select(x => new PersonDto
                            {
                                Id = x.Id,
                                FullName = x.FullName,
                                Role = x.Role,
                                Phone = x.Contact?.Phone,
                                Email = x.Contact?.Email,
                                Address = x.Contact?.Address,
                                Photo = x.Biometrics?.Photo
                            })
                            .ToList();
                        break;

                    case "Cases":
                        dataGridViewDetective.DataSource = currentData.Cases?
                            .Select(x => new CaseDto
                            {
                                Id = x.Id,
                                Title = x.Title,
                                Status = x.Status?.CurrentStatus,
                                CrimeType = x.CrimeDetails?.CrimeType,
                                Location = x.CrimeDetails?.CrimeLocation,
                                Detective = x.CrimeDetails?.LeadDetective
                            })
                            .ToList();
                        break;

                    case "Hypotheses":
                        dataGridViewDetective.DataSource = currentData.Hypotheses?
                            .Select(x => new HypothesisDto
                            {
                                Id = x.Id,
                                Description = x.Description,
                                Priority = x.Priority?.Level,
                                CreatorName = x.Creator?.Name,
                                IsConfirmed = x.Confirmation?.IsConfirmed ?? false
                            })
                            .ToList();
                        break;

                    case "Motives":
                        dataGridViewDetective.DataSource = currentData.Motives?
                            .Select(x => new MotiveDto
                            {
                                Id = x.Id,
                                PersonName = x.Person?.Name,
                                Type = x.MotiveDetails?.Type,
                                Strength = x.MotiveDetails?.Strength ?? 0,
                                Description = x.MotiveDetails?.Description
                            })
                            .ToList();
                        break;

                    case "InvestigativeActions":
                        dataGridViewDetective.DataSource = currentData.InvestigativeActions?
                            .Select(x => new InvestigativeActionDto
                            {
                                Id = x.Id,
                                ActionType = x.ActionType?.Name,
                                Target = x.Target?.PersonName,
                                Result = x.Result?.Summary,
                                Date = x.Result?.Date
                            })
                            .ToList();
                        break;

                    case "LocationTimes":
                        dataGridViewDetective.DataSource = currentData.LocationTimes?
                            .Select(x => new LocationTimeDto
                            {
                                Id = x.Id,
                                Person = x.Person?.Name,
                                Location = x.Location?.Name,
                                Enter = x.TimeInterval?.Enter,
                                Exit = x.TimeInterval?.Exit
                            })
                            .ToList();
                        break;

                    case "Meetings":
                        dataGridViewDetective.DataSource = currentData.Meetings?
                            .Select(x => new MeetingDto
                            {
                                Id = x.Id,
                                PersonA = x.PersonA?.Name,
                                PersonB = x.PersonB?.Name,
                                Location = x.MeetingDetails?.Location,
                                Time = x.MeetingDetails?.Time,
                                IsSecret = x.MeetingDetails?.IsSecret ?? false
                            })
                            .ToList();
                        break;

                    case "Evidences":
                        dataGridViewDetective.DataSource = currentData.Evidences?
                            .Select(x => new EvidenceDto
                            {
                                Id = x.Id,
                                Category = x.EvidenceType?.Category,
                                Description = x.Description?.Short,
                                FoundAt = x.FoundInfo?.Location,
                                FoundBy = x.FoundInfo?.FoundBy,
                                Suspect = x.PointsTo?.PersonName
                            })
                            .ToList();
                        break;

                    case "Clues":
                        dataGridViewDetective.DataSource = currentData.Clues?
                            .Select(x => new ClueDto
                            {
                                Id = x.Id,
                                From = x.FromEvidence?.Description,
                                To = x.ToEvidence?.Description,
                                Rule = x.InferenceRule?.RuleText,
                                Confidence = x.Confidence?.Level
                            })
                            .ToList();
                        break;
                }

                dataGridViewDetective.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                LocalizeColumns(entityType);
                ApplyRowColors(entityType);
            }
            finally
            {
                dataGridViewDetective.ResumeLayout();
            }
        }
        /// <summary>
        /// Загружает данные из XML-файла
        /// </summary>
        private void btnLoadXML_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(DetectiveData));
                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                        currentData = (DetectiveData)serializer.Deserialize(fs);
                    MessageBox.Show("XML загружен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Загружает данные из JSON-файла
        /// </summary>
        private void btnLoadJSON_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var json = File.ReadAllText(openFileDialog.FileName);
                    currentData = JsonConvert.DeserializeObject<DetectiveData>(json);
                    MessageBox.Show("JSON загружен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Показывает форму с детальной информацией о выбранной записи
        /// </summary>
        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            if (currentData == null)
            {
                MessageBox.Show("Сначала загрузите файл!");
                return;
            }

            if (dataGridViewDetective.CurrentRow == null)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }

            dynamic selectedItem = dataGridViewDetective.CurrentRow.DataBoundItem;
            var id = selectedItem.Id;

            if (treeViewdetective.SelectedNode == null)
            {
                MessageBox.Show("Выберите сущность в дереве!");
                return;
            }

            var currentEntityType = treeViewdetective.SelectedNode.Name;
            Forms.Details detailsForm = new Forms.Details(currentData, currentEntityType, id);
            detailsForm.ShowDialog();
        }
        /// <summary>
        /// Заголовки столбцов на русском
        /// </summary>
        private void LocalizeColumns(string entityType)
        {
            var grid = dataGridViewDetective;

            if (grid.Columns.Count == 0) return;

            if (entityType == "Persons")
            {
                grid.Columns["Id"].HeaderText = "ID";
                grid.Columns["FullName"].HeaderText = "ФИО";
                grid.Columns["Role"].HeaderText = "Роль";
                grid.Columns["Phone"].HeaderText = "Телефон";
                grid.Columns["Email"].HeaderText = "Почта";
                grid.Columns["Address"].HeaderText = "Адрес";
                grid.Columns["Photo"].HeaderText = "Фото";

                grid.Columns["Id"].Visible = false; 
            }

            else if (entityType == "Cases")
            {
                grid.Columns["Id"].HeaderText = "ID";
                grid.Columns["Title"].HeaderText = "Название";
                grid.Columns["Status"].HeaderText = "Статус";
                grid.Columns["CrimeType"].HeaderText = "Тип преступления";
                grid.Columns["Location"].HeaderText = "Место";
                grid.Columns["Detective"].HeaderText = "Детектив";

                grid.Columns["Id"].Visible = false;
            }

            else if (entityType == "Hypotheses")
            {
                grid.Columns["Id"].HeaderText = "ID";
                grid.Columns["Description"].HeaderText = "Описание";
                grid.Columns["Priority"].HeaderText = "Приоритет";
                grid.Columns["CreatorName"].HeaderText = "Создатель";
                grid.Columns["IsConfirmed"].HeaderText = "Подтверждена";

                grid.Columns["Id"].Visible = false;
            }

            else if (entityType == "Motives")
            {
                grid.Columns["Id"].HeaderText = "ID";
                grid.Columns["PersonName"].HeaderText = "Человек";
                grid.Columns["Type"].HeaderText = "Тип";
                grid.Columns["Strength"].HeaderText = "Сила";
                grid.Columns["Description"].HeaderText = "Описание";

                grid.Columns["Id"].Visible = false;
            }

            else if (entityType == "InvestigativeActions")
            {
                grid.Columns["Id"].HeaderText = "ID";
                grid.Columns["ActionType"].HeaderText = "Действие";
                grid.Columns["Target"].HeaderText = "Цель";
                grid.Columns["Result"].HeaderText = "Результат";
                grid.Columns["Date"].HeaderText = "Дата";

                grid.Columns["Id"].Visible = false;
            }

            else if (entityType == "LocationTimes")
            {
                grid.Columns["Id"].HeaderText = "ID";
                grid.Columns["Person"].HeaderText = "Человек";
                grid.Columns["Location"].HeaderText = "Место";
                grid.Columns["Enter"].HeaderText = "Вход";
                grid.Columns["Exit"].HeaderText = "Выход";

                grid.Columns["Id"].Visible = false;
            }

            else if (entityType == "Meetings")
            {
                grid.Columns["Id"].HeaderText = "ID";
                grid.Columns["PersonA"].HeaderText = "Участник A";
                grid.Columns["PersonB"].HeaderText = "Участник B";
                grid.Columns["Location"].HeaderText = "Место";
                grid.Columns["Time"].HeaderText = "Время";
                grid.Columns["IsSecret"].HeaderText = "Тайная";

                grid.Columns["Id"].Visible = false;
            }

            else if (entityType == "Evidences")
            {
                grid.Columns["Id"].HeaderText = "ID";
                grid.Columns["Category"].HeaderText = "Категория";
                grid.Columns["Description"].HeaderText = "Описание";
                grid.Columns["FoundAt"].HeaderText = "Где найдено";
                grid.Columns["FoundBy"].HeaderText = "Кем найдено";
                grid.Columns["Suspect"].HeaderText = "Подозреваемый";

                grid.Columns["Id"].Visible = false;
            }

            else if (entityType == "Clues")
            {
                grid.Columns["Id"].HeaderText = "ID";
                grid.Columns["From"].HeaderText = "От";
                grid.Columns["To"].HeaderText = "К";
                grid.Columns["Rule"].HeaderText = "Правило";
                grid.Columns["Confidence"].HeaderText = "Уверенность";

                grid.Columns["Id"].Visible = false;
            }
        }
        /// <summary>
        /// Применяет цветовую подсветку строк в зависимости от роли человека
        /// </summary>
        private void ApplyRowColors(string entityType)
        {
            if (entityType != "Persons")
                return;

            foreach (DataGridViewRow row in dataGridViewDetective.Rows)
            {
                if (row.DataBoundItem is PersonDto person)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.DefaultCellStyle.SelectionForeColor = Color.Black;

                    switch (person.Role?.ToLower())
                    {
                        case "подозреваемый":
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                            row.DefaultCellStyle.SelectionBackColor = Color.IndianRed;
                            break;

                        case "детектив":
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            row.DefaultCellStyle.SelectionBackColor = Color.PaleGreen;
                            break;

                        case "потерпевший":
                            row.DefaultCellStyle.BackColor = Color.Gainsboro;
                            row.DefaultCellStyle.SelectionBackColor = Color.Silver;
                            break;

                        case "свидетель":
                            row.DefaultCellStyle.BackColor = Color.LightBlue;
                            row.DefaultCellStyle.SelectionBackColor = Color.SkyBlue;
                            break;

                        default:
                            row.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                            break;
                    }
                }
            }
        }
    }
}