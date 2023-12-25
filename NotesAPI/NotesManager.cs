using System;
using System.Collections.Generic;
using System.IO;

namespace NotesAPI
{
    public class NotesManager
    {
        public void AddingNotes(List<NotesModel> models)
        {
            NotesModel noteModel = new NotesModel();

            Console.Write("Insert the Title of the Note: ");
            noteModel.Title = Console.ReadLine();

            Console.Write("Insert the Note: ");
            noteModel.Notes = Console.ReadLine();

            models.Add(noteModel);

            SaveInFile(models);
        }

        public void DeleteNotes(List<NotesModel> models)
        {
            DisplayNotes(models);

            Console.Write("Insert the number of the note that you want to delete: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= models.Count)
            {
                Console.WriteLine("Note Deleted!");
                models.RemoveAt(choice - 1);
            }
            else
            {
                Console.WriteLine("Invalid note number!");
            }

            SaveInFile(models);
        }

        public void EditNotes(List<NotesModel> models)
        {
            DisplayNotes(models);

            Console.Write("Insert the number of the note that you want to edit: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= models.Count)
            {
                NotesModel notesModel = new NotesModel();

                Console.Write("Insert the new title: ");
                notesModel.Title = Console.ReadLine();

                Console.Write("Insert the new note: ");
                notesModel.Notes = Console.ReadLine();

                Console.WriteLine("Note Edit!");
                models[choice - 1] = notesModel;
            }
            else
            {
                Console.WriteLine("Invalid note number!");
            }

            SaveInFile(models);
        }

        public void ShowNotes(List<NotesModel> models)
        {
            Console.WriteLine("=================================================");
            DisplayNotes(models);
            Console.WriteLine("=================================================");
        }

        private void DisplayNotes(List<NotesModel> models)
        {
            foreach (var model in models)
            {
                Console.WriteLine($"Title: {model.Title}\nNote: {model.Notes}\n");
            }
            if (models.Count == 0)
            {
                Console.WriteLine("There are no notes here!");
            }
        }

        private void SaveInFile(List<NotesModel> models)
        {
            try
            {
                string filePath = GetFilePath();
                using (StreamWriter file = new StreamWriter(filePath))
                {
                    foreach (var model in models)
                    {
                        file.WriteLine($"Title: {model.Title}\nNote: {model.Notes}\n");
                    }
                }

                Console.WriteLine("Notes saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the notes: {ex.Message}");
            }
        }

        private string GetFilePath()
        {
            string directoryPath = "NotesFiles";
            string fileName = "File.txt";
            string filePath = Path.Combine(directoryPath, fileName);

            // Create directory if it doesn't exist
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            return filePath;
        }
    }
}