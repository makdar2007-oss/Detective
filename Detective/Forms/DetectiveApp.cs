using Detective.DTO;
using Detective.Forms;
using Detective.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                new Font("Segoe UI", 12, FontStyle.Bold);

            dataGridViewDetective.AutoGenerateColumns = true;
            dataGridViewDetective.ReadOnly = true;
            dataGridViewDetective.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDetective.MultiSelect = false;
            dataGridViewDetective.AllowUserToAddRows = false;
            dataGridViewDetective.AllowUserToDeleteRows = false;
            dataGridViewDetective.AllowUserToResizeRows = false;
            dataGridViewDetective.RowHeadersVisible = false;
            dataGridViewDetective.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void TreeViewdetective_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var entityType = e.Node.Name;
            LoadDataToGrid(entityType);
        }

        private void LoadDataToGrid(string entityType)
        {
            if (currentData == null)
                return;

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
                                FirstName = x.FirstName,
                                LastName = x.LastName,
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
                                NumberId = x.NumberId,
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

                LocalizeColumns(entityType);
                ApplyRowColors(entityType);
                HideTechnicalColumns();
            }
            finally
            {
                dataGridViewDetective.ResumeLayout();
            }
        }
        private void btnLoadXML_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "XML files (*.xml)|*.xml";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var serializer = new XmlSerializer(typeof(DetectiveData));
                using (var fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    currentData = (DetectiveData)serializer.Deserialize(fs);
                }

                ValidateLoadedData();
                MessageBox.Show("XML загружен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки XML:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadJSON_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "JSON files (*.json)|*.json";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var json = File.ReadAllText(openFileDialog.FileName);

                currentData = JsonConvert.DeserializeObject<DetectiveData>(
                    json,
                    new JsonSerializerSettings
                    {
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                        NullValueHandling = NullValueHandling.Include
                    });

                ValidateLoadedData();
                MessageBox.Show("JSON загружен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки JSON:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

            if (treeViewdetective.SelectedNode == null)
            {
                MessageBox.Show("Выберите сущность в дереве!");
                return;
            }

            if (dataGridViewDetective.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Не удалось получить выбранную запись!");
                return;
            }

            var boundItem = dataGridViewDetective.CurrentRow.DataBoundItem;
            var idProperty = boundItem.GetType().GetProperty("Id");

            if (idProperty == null || idProperty.PropertyType != typeof(Guid))
            {
                MessageBox.Show("У выбранной записи не найден id!");
                return;
            }

            var id = (Guid)idProperty.GetValue(boundItem);
            var currentEntityType = treeViewdetective.SelectedNode.Name;

            using (var detailsForm = new Details(currentData, currentEntityType, id))
            {
                detailsForm.ShowDialog();
            }
        }

        private void ValidateLoadedData()
        {
            if (currentData == null)
                throw new Exception("Файл не удалось десериализовать.");

            if (currentData.Persons == null)
                currentData.Persons = new List<Person>();

            if (currentData.Cases == null)
                currentData.Cases = new List<Case>();

            if (currentData.Hypotheses == null)
                currentData.Hypotheses = new List<Hypothesis>();

            if (currentData.Motives == null)
                currentData.Motives = new List<Motive>();

            if (currentData.InvestigativeActions == null)
                currentData.InvestigativeActions = new List<InvestigativeAction>();

            if (currentData.LocationTimes == null)
                currentData.LocationTimes = new List<LocationTime>();

            if (currentData.Meetings == null)
                currentData.Meetings = new List<Meeting>();

            if (currentData.Evidences == null)
                currentData.Evidences = new List<Evidence>();

            if (currentData.Clues == null)
                currentData.Clues = new List<Clue>();
        }

        private void HideTechnicalColumns()
        {
            if (dataGridViewDetective.Columns.Contains("Id"))
                dataGridViewDetective.Columns["Id"].Visible = false;

            if (dataGridViewDetective.Columns.Contains("Photo"))
                dataGridViewDetective.Columns["Photo"].Visible = false;
        }

        private void LocalizeColumns(string entityType)
        {
            var grid = dataGridViewDetective;
            if (grid.Columns.Count == 0)
                return;

            switch (entityType)
            {
                case "Persons":
                    SetHeader("FullName", "ФИО");
                    SetHeader("Role", "Роль");
                    SetHeader("Phone", "Телефон");
                    SetHeader("Email", "Почта");
                    SetHeader("Address", "Адрес");

                    if (dataGridViewDetective.Columns.Contains("FirstName"))
                        dataGridViewDetective.Columns["FirstName"].Visible = false;

                    if (dataGridViewDetective.Columns.Contains("LastName"))
                        dataGridViewDetective.Columns["LastName"].Visible = false;
                    break;

                case "Cases":
                    SetHeader("NumberId", "Номер");
                    SetHeader("Title", "Название");
                    SetHeader("Status", "Статус");
                    SetHeader("CrimeType", "Тип преступления");
                    SetHeader("Location", "Место");
                    SetHeader("Detective", "Детектив");
                    break;

                case "Hypotheses":
                    SetHeader("Description", "Описание");
                    SetHeader("Priority", "Приоритет");
                    SetHeader("CreatorName", "Автор");
                    SetHeader("IsConfirmed", "Подтверждена");
                    break;

                case "Motives":
                    SetHeader("PersonName", "Подозреваемый");
                    SetHeader("Type", "Тип");
                    SetHeader("Strength", "Сила");
                    SetHeader("Description", "Описание");
                    break;

                case "InvestigativeActions":
                    SetHeader("ActionType", "Действие");
                    SetHeader("Target", "Цель");
                    SetHeader("Result", "Результат");
                    SetHeader("Date", "Дата");
                    break;

                case "LocationTimes":
                    SetHeader("Person", "Человек");
                    SetHeader("Location", "Локация");
                    SetHeader("Enter", "Вход");
                    SetHeader("Exit", "Выход");
                    break;

                case "Meetings":
                    SetHeader("PersonA", "Участник 1");
                    SetHeader("PersonB", "Участник 2");
                    SetHeader("Location", "Место");
                    SetHeader("Time", "Время");
                    SetHeader("IsSecret", "Тайная");
                    break;

                case "Evidences":
                    SetHeader("Category", "Категория");
                    SetHeader("Description", "Описание");
                    SetHeader("FoundAt", "Где найдено");
                    SetHeader("FoundBy", "Кто нашёл");
                    SetHeader("Suspect", "Указывает на");
                    break;

                case "Clues":
                    SetHeader("From", "Из улики");
                    SetHeader("To", "К улике");
                    SetHeader("Rule", "Правило");
                    SetHeader("Confidence", "Уверенность");
                    break;
            }
        }

        private void SetHeader(string columnName, string headerText)
        {
            if (dataGridViewDetective.Columns.Contains(columnName))
                dataGridViewDetective.Columns[columnName].HeaderText = headerText;
        }

        private void ApplyRowColors(string entityType)
        {
            foreach (DataGridViewRow row in dataGridViewDetective.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;

                if (entityType == "Persons" &&
                    row.Cells["Role"]?.Value?.ToString()?.ToLower() == "подозреваемый")
                {
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
                }

                if (entityType == "Meetings" &&
                    row.Cells["IsSecret"]?.Value is bool isSecret &&
                    isSecret)
                {
                    row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                }

                if (entityType == "Hypotheses" &&
                    row.Cells["IsConfirmed"]?.Value is bool confirmed &&
                    confirmed)
                {
                    row.DefaultCellStyle.BackColor = Color.Honeydew;
                }
            }
        }
    }
}