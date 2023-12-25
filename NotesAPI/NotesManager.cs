using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NotesAPI
{
    public class NotesManager
    {
        public void AddingNotes(List<NotesModel> models)
        {
            NotesModel NoteModel = new NotesModel();

            Console.WriteLine("Insert the Title of the Note: ");
            NoteModel.Title = Console.ReadLine();

            Console.WriteLine("Insert the Note: ");
            NoteModel.Notes = Console.ReadLine();

            models.Add(NoteModel);

            SaveInFile(models);
        }

        public void DeleteNotes(List<NotesModel> models)
        {
            foreach (var model in models)
            {
                Console.WriteLine($"Note Number: {models.IndexOf(model) + 1}");
                Console.WriteLine($"Title: {model.Title}\nNote: {model.Notes}\n");
            }
            Console.WriteLine("Insert the number of the note that you want to delete: ");
            int Choice = Convert.ToInt32(Console.ReadLine());
            
            if(Choice >= 1 && Choice <= models.Count)
            {
                Console.WriteLine("Note Deleted!");
                models.Remove(models[Choice - 1]);
            }
            else
            {
                Console.WriteLine("Insert a valid note number!");
            }
            SaveInFile(models);
        }

        public void EditNotes(List<NotesModel> models)
        {
            NotesModel notesModel = new NotesModel();
            foreach (var model in models)
            {
                Console.WriteLine($"Note Number: {models.IndexOf(model) + 1}");
                Console.WriteLine($"Title: {model.Title}\nNote: {model.Notes}\n");
            }
            Console.WriteLine("Insert the number of the note that you want to edit: ");
            int Choice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Insert the new title: ");
            notesModel.Title = Console.ReadLine();

            Console.WriteLine("Insert the new note: ");
            notesModel.Notes = Console.ReadLine();

            if (Choice >= 1 && Choice <= models.Count)
            {
                Console.WriteLine("Note Edit!");
                models[Choice - 1] = notesModel;
            }
            else
            {
                Console.WriteLine("Insert a valid note number!");
            }
            SaveInFile(models);
        }

        public void ShowNotes(List<NotesModel> models)
        {
            Console.WriteLine("=================================================");
            foreach (var model in models)
            {
                Console.WriteLine($"Title: {model.Title}\nNote: {model.Notes}\n");
            }
            if (!models.Any())
            {
                Console.WriteLine("There isn't notes here!");
            }
            Console.WriteLine("=================================================");
        }

        private void SaveInFile(List<NotesModel> models)
        {
            string Path = "D:/LogNotes/File.txt";

            StreamWriter File = new StreamWriter(Path);
            foreach (var model in models)
            {
                File.WriteLine($"Title: {model.Title}\nNote: {model.Notes}\n");
            }
            File.Close();
        }
    }
}
